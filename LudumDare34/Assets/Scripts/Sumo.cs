using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Sumo : MonoBehaviour {

    // Atributos del personaje
    public int strength;
    public int resistance;
    public int defense;

    // Estado del personaje:
    //    0 - Inicio
    //    1 - Reposo
    //    2 - Aturdido
    //    3 - Ataque
    //    4 - Ataque Fuerte
    //    5 - Defensa
    private int estado;

    // Tiempos de defensa y ataque
    private float defTime;
    private float atqTime;

    // Use this for initialization
    void Start () {
        // Animación de inicio
        estado = 0;

        if (this.name.Contains("Jugador"))
        {
            strength += GameManager.instance.BonusStrength;
            resistance += GameManager.instance.BonusResistance;
            defense += GameManager.instance.BonusDefense;
        }
	}
	
	// Update is called once per frame
	void Update () {

        // Si está en reposo y el tiempo de defensa no está al máximo se recupera
        if (estado == 1 && defTime < defense / 2)
        {
            defTime += Time.deltaTime / 2;
        }

        // Si se pulsa "A" y está en estado de reposo o aturdido se defiende
        if (Input.GetKeyDown(KeyCode.A) && (estado == 1 || estado == 2) && defTime >= 0.5)
        {
            atqTime = 0;
            estado = 5;
        }

        // Si se deja de pulsar "A" vuelve a reposo
        if (Input.GetKeyUp(KeyCode.A))
        {
            estado = 1;
        }

        // Si está defendiendo baja el tiempo
        if (estado == 5)
        {
            defTime -= Time.deltaTime;

            // Si se acaba el tiempo de defensa pasa a reposo
            if(defTime <= 0)
            {
                defTime = 0;
                estado = 1;
            }
        }

        // Si está en reposo y pulsa "D" aumenta el tiepo de ataque
        if (estado == 1 && Input.GetKey(KeyCode.D))
        {
            atqTime += Time.deltaTime;
        }

        // Si deja de pulsar el botón "D" se lanza el ataque dependiendo del tiempo pulsado
        if(Input.GetKeyUp(KeyCode.D) && atqTime > 0)
        {
            // Si se pulsó durante más de 0.5 seg
            /*
            if (atqTime > 0.5)
                // TODO Lanza ataque fuerte
                null;
            else
                // TODO Lanza ataque normal
                null;
            atqTime = 0;
            */
        }

        // Si está aturdido, deja de atacar:
        if (estado == 2)
        {
            atqTime = 0;
        }
  
	}
}
