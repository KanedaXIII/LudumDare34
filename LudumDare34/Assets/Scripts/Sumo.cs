using UnityEngine;
using UnityEngine.UI;

public class Sumo : MonoBehaviour {

    // Enlaces con la UI
    public Text strText;
    public Text resText;
    public Text defText;
    public Slider atqBar;
    public Slider defBar;

    // Atributos del personaje
    private int strength = 3;
    private int resistance = 3;
    private int defense = 3;

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
        estado = 1;        

        // Añadimos los bonus de la comida
        if (this.name.Contains("Jugador"))
        {
            strength += GameManager.instance.BonusStrength;
            resistance += GameManager.instance.BonusResistance;
            defense += GameManager.instance.BonusDefense;
        }

        strText.text = strength.ToString();
        resText.text = resistance.ToString();
        defText.text = defense.ToString();

        // Iniciamos los tiempos
        defTime = defense / 2;
        atqTime = 0;
    }

    // Update is called once per frame
    void Update () {

        // Si está en reposo y el tiempo de defensa no está al máximo se recupera
        if (estado == 1 && defTime < defense / 2)
        {
            defTime += Time.deltaTime / 2;
        }

        // Si se pulsa "A" y está en estado de reposo o aturdido se defiende
        if (Input.GetKeyDown(KeyCode.A) && (estado == 1 || estado == 2) && defTime >= 0.5f)
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
            if(atqTime > 0.5f)
                atqTime = 0.5f;
        }

        // Si deja de pulsar el botón "D" se lanza el ataque dependiendo del tiempo pulsado
        if(Input.GetKeyUp(KeyCode.D) && atqTime > 0)
        {
            // Si se pulsó durante más de 0.5 seg

            if (atqTime == 0.5f)
                // TODO Lanza ataque fuerte
                atqTime = 0;
            else
                // TODO Lanza ataque normal
                atqTime = 0;
            
        }

        // Si está aturdido, deja de atacar:
        if (estado == 2)
        {
            atqTime = 0;
        }

        atqBar.value = atqTime / 0.5f;
        defBar.value = defTime / (defense / 3);
  
	}
}
