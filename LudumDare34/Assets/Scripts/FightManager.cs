using UnityEngine;
using System.Collections;

public class FightManager : MonoBehaviour {

    // Objetos Sumos del combate
    public Sumo player;
    public Sumo enemy;

    // Sonidos del combate;
    public AudioClip punchsound;
    public AudioClip damageSound1;
    public AudioClip damageSound2;
    public AudioClip countersound;


    public static FightManager instance = null; // Allows other scripts to call functions from FightManager.

    // Fuerzas calculadas
    private float playerPower;
    private float enemyPower;

    void Awake()
    {
        // Check if there is already an instance of FightManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of FightManager.
            Destroy(gameObject);

        //Calcula las fuerzas
        playerPower = Mathf.Max(player.Strength - enemy.Resistance, 0) * 10 + 100;
        enemyPower = Mathf.Max(enemy.Strength - player.Resistance, 0) * 10 + 100;
    }

    public void playerAttack()
    {
        // Si el enemigo se está defendiendo es un contraataque
        if (enemy.State == 5)
        {
            SoundManager.instance.PlaySingle(countersound);
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * enemyPower);
            SoundManager.instance.PlaySingle2(damageSound2);
        }
        else // Si no, el ataque tiene éxito
        {
            SoundManager.instance.PlaySingle(punchsound);
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * playerPower);
            GameManager.instance.Attacks++;
            SoundManager.instance.PlaySingle2(damageSound1);
        }
    }

    public void enemyAttack()
    {


        // Si el jugador se está defendiendo es un contraataque
        if (player.State == 5)
        {
            SoundManager.instance.PlaySingle(countersound);
            GetComponent<Rigidbody2D>().AddForce(Vector2.right * playerPower);
            GameManager.instance.Counters++;
            SoundManager.instance.PlaySingle2(damageSound2);
        }
        else // Si no, el ataque tiene éxito
        {
            SoundManager.instance.PlaySingle(punchsound);
            GetComponent<Rigidbody2D>().AddForce(Vector2.left * enemyPower);
            SoundManager.instance.PlaySingle2(damageSound1);
        }
    }

    public void combatWin()
    {
        //TODO muestra VICTORIA
        GameManager.instance.ChangeScene("Restaurant");
    }

    public void combatLose()
    {

    }

}
