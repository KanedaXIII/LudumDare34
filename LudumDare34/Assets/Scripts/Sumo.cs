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
    private int state;

    // Tiempos de defensa y ataque
    private float defTime;
    private float atqTime;

    // Use this for initialization
    void Start () {
        // Animación de inicio
        State = 1;        

        // Añadimos los bonus de la comida
        if (this.name.Contains("Player"))
        {
            Strength += GameManager.instance.BonusStrength;
            Resistance += GameManager.instance.BonusResistance;
            Defense += GameManager.instance.BonusDefense;
        }
        else if (GameManager.instance.Wins > 0) // añadimos los bonus de dificultad
        {
            strength += Random.Range(0, GameManager.instance.Wins * 3);
            resistance += Random.Range(0, GameManager.instance.Wins * 3);
            defense += Random.Range(0, GameManager.instance.Wins * 3);
        }

        strText.text = Strength.ToString();
        resText.text = Resistance.ToString();
        defText.text = Defense.ToString();

        // Iniciamos los tiempos
        defTime = Defense / 2;
        atqTime = 0;
    }

    // Update is called once per frame
    void Update () {

        // Controles del jugador
        if (this.name.Contains("Player"))
        {
            // Si se pulsa "A" y está en estado de reposo o aturdido se defiende
            if (Input.GetKeyDown(KeyCode.A) && (State == 1 || State == 2))
            {
                atqTime = 0;
                State = 5;
                GameManager.instance.Defenses++;
            }

            // Si se deja de pulsar "A" vuelve a reposo
            if (Input.GetKeyUp(KeyCode.A) && State == 5)
            {
                State = 1;
            }

            // Si pulsa "D" y está en reposo ataca 
            if (Input.GetKeyDown(KeyCode.D) && State == 1)
            {
                State = 3;
            }

            // Si deja de pulsar el botón "D" vuelve a reposo
            if (Input.GetKeyUp(KeyCode.D) && State == 3)
            {
                State = 1;
                atqTime = 0;
            }
        }
        //else //Controles de la máquina
        //{
        //    // Si está en reposo y el tiempo de defensa está al máximo se defiende
        //    if (State == 1 && defTime == Defense / 2)
        //    {
        //        State = 5;
        //    }

        //    // Si está en reposo y el tiempo de defensa está al mínimo ataca
        //    if (State == 1 && defTime == 0)
        //    {
        //        State = 3;
        //    }
        //}

        // Si no está defendiendo y el tiempo de defensa no está al máximo se recupera
        if (State != 5 && defTime < Defense / 2)
        {
            defTime += Time.deltaTime / 3;
            if (defTime > Defense / 2)
                defTime = Defense / 2;
        }

        // Si está defendiendo baja el tiempo
        if (State == 5)
        {
            defTime -= Time.deltaTime;

            // Si se acaba el tiempo de defensa pasa a reposo
            if(defTime <= 0)
            {
                defTime = 0;
                State = 1;
            }
        }

        // Si está atacando sube el tiempo y si alcanza el máximo lanza el ataque y pasa a reposo
        if (State == 3)
        {
            atqTime += Time.deltaTime;
            if (atqTime > 0.5f)
            {
                State = 1; 
                atqTime = 0;
                // Lanza el ataque dependiendo si es el jugador o la máquina
                if (this.name.Contains("Player"))
                    FightManager.instance.playerAttack();
                else
                    FightManager.instance.enemyAttack();
            }
        }

        // Si está aturdido, deja de atacar:
        if (State == 2)
        {
            atqTime = 0;
        }

        // Actualizamos los valores de las barras
        atqBar.value = atqTime / 0.5f;
        defBar.value = defTime / (Defense / 2);
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name== "Borders")
        {
            // Si el jugador sale del tatami
            if (this.tag == "player")
            {
                Debug.Log("Estoy entrando papa");
                FightManager.instance.combatLose();
            }
            else
            {
                // Si el enemigo sale del tatami
                FightManager.instance.combatWin();
            }
        }
       
    }

    public int Strength
    {
        get
        {
            return strength;
        }

        set
        {
            strength = value;
        }
    }

    public int Resistance
    {
        get
        {
            return resistance;
        }

        set
        {
            resistance = value;
        }
    }

    public int Defense
    {
        get
        {
            return defense;
        }

        set
        {
            defense = value;
        }
    }

    public int State
    {
        get
        {
            return state;
        }

        set
        {
            state = value;
        }
    }
}
