﻿using System;
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

    //Atributos de escala del personaje
    public float bellyScale = 0.8f;

    // Atributos para almacenar las estadísticas de la partida
    private int wins = 0;
    private int attacks = 0;
    private int bigAttacks = 0;
    private int defenses = 0;
    private int counters = 0;

    // Sonidos del juego
    public AudioClip menuMusic;
    public AudioClip restaurantMusic;
    public AudioClip tatamiMusic;

    // TODO Controlador de menú principal
    // private MainMenuController mainMenuController;

	public CanvasGroup buttonGroup;
	public CanvasGroup creditsGroup;
    public CanvasGroup tutorialGroup;

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
            GameManager.instance.Defenses = 0;
            GameManager.instance.Counters = 0;
            GameManager.instance.bellyScale = 0.8f; 
        }

        // Cambiar de escena
        SceneManager.LoadScene(sceneName);
    }

    public void ShowTutorial()
    {
        this.buttonGroup.interactable = false;
        this.buttonGroup.blocksRaycasts = false;

        this.tutorialGroup.interactable = true;
        this.tutorialGroup.blocksRaycasts = true;
        this.tutorialGroup.alpha = 1.0f;
    }

    public void ShowCredits()
	{
		this.buttonGroup.interactable = false;
		this.buttonGroup.blocksRaycasts = false;

		this.creditsGroup.interactable = true;
		this.creditsGroup.blocksRaycasts = true;
		this.creditsGroup.alpha = 1.0f;
	}

    public void HideTutorial()
    {
        this.buttonGroup.interactable = true;
        this.buttonGroup.blocksRaycasts = true;

        this.tutorialGroup.interactable = false;
        this.tutorialGroup.blocksRaycasts = false;
        this.tutorialGroup.alpha = 0.0f;
    }

    public void HideCredits()
	{
		this.buttonGroup.interactable = true;
		this.buttonGroup.blocksRaycasts = true;

		this.creditsGroup.interactable = false;
		this.creditsGroup.blocksRaycasts = false;
		this.creditsGroup.alpha = 0.0f;
	}

	private IEnumerator FadeInCredits()
	{
		while (this.creditsGroup.alpha <= 1.0f) {
			this.creditsGroup.alpha += 0.04f;
			yield return null;
		}
		this.creditsGroup.alpha = 1.0f;
		yield break;
	}

	private IEnumerator FadeOutCredits()
	{
		while (this.creditsGroup.alpha >= 0.0f) {
			this.creditsGroup.alpha -= 0.04f;
			yield return null;
		}
		this.creditsGroup.alpha = 0.0f;
	}

    public void QuitGame()
    {
        Application.Quit();
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

    public int Defenses
    {
        get
        {
            return defenses;
        }

        set
        {
            defenses = value;
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