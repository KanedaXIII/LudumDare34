using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null; //Permite a otros scrips llamar funciones del GameManager

    // Atributos para almacenar los bonus de las comidas
    private int bonusStrength = 0;      
    private int bonusResistance = 0;
    private int bonusDefense = 0;

    // Atributos para almacenar las estadísticas de la partida
    private int wins = 0;
    private int attacks = 0;
    private int bigAttacks = 0;
    private int blocks = 0;
    private int counters = 0;

    // Sonidos del juego
    public AudioClip menuMusic;
    public AudioClip restaurantMusic;
    public AudioClip tatamiMusic;

    // TODO Controlador de menú principal
    // private MainMenuController mainMenuController;

    void Awake()
    {
        // Comprueba si ya hay una instancia del GameManager
        if (instance == null)
            //Si no, establécela como esta
            instance = this;
        // Si ya existe una instancia:
        else if (instance != this)
            // Destrúyela, esto asegura que nuestro patrón singleton no tenga más de una instancia del GameManager
            Destroy(gameObject);

        // Establece que nuestro GameManager no se destruya cuando cambiamos de scene
        DontDestroyOnLoad(gameObject);

        // TODO this.mainMenuController = this.FindMainMenuController();
    }

    private void OnLevelWasLoaded(int level)
    {
        // Iniciamos la música de la pantalla
        if (SceneManager.GetActiveScene().name == "Main menu")
            SoundManager.instance.PlayMusic(menuMusic);
        else if (SceneManager.GetActiveScene().name == "Restaurant")
            SoundManager.instance.PlayMusic(restaurantMusic);
        else if (SceneManager.GetActiveScene().name == "Tatami")
            SoundManager.instance.PlayMusic(tatamiMusic);
    }

    public void ChangeScene(string sceneName)
    {
        // Si volvemos al menú principal
        if(sceneName == "Main menu")
        {
            // Reiniciamos los parámetros del juego
            GameManager.instance.BonusStrength = 0;
            GameManager.instance.BonusResistance = 0;
            GameManager.instance.BonusDefense = 0;
            GameManager.instance.Wins = 0;
            GameManager.instance.Attacks = 0;
            GameManager.instance.BigAttacks = 0;
            GameManager.instance.Blocks = 0;
            GameManager.instance.Counters = 0;
        }

        // Cambiar de escena
        SceneManager.LoadScene(sceneName);
    }

    public int BonusStrength
    {
        get
        {
            return bonusStrength;
        }

        set
        {
            bonusStrength = value;
        }
    }

    public int BonusResistance
    {
        get
        {
            return bonusResistance;
        }

        set
        {
            bonusResistance = value;
        }
    }

    public int BonusDefense
    {
        get
        {
            return bonusDefense;
        }

        set
        {
            bonusDefense = value;
        }
    }

    public int Wins
    {
        get
        {
            return wins;
        }

        set
        {
            wins = value;
        }
    }

    public int Attacks
    {
        get
        {
            return attacks;
        }

        set
        {
            attacks = value;
        }
    }

    public int BigAttacks
    {
        get
        {
            return bigAttacks;
        }

        set
        {
            bigAttacks = value;
        }
    }

    public int Blocks
    {
        get
        {
            return blocks;
        }

        set
        {
            blocks = value;
        }
    }

    public int Counters
    {
        get
        {
            return counters;
        }

        set
        {
            counters = value;
        }
    }

}