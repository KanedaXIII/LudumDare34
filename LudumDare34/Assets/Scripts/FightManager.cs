using UnityEngine;
using System.Collections;

public class FightManager : MonoBehaviour {

    // Objetos Sumos del combate
    public Sumo player;
    public Sumo enemy;

    public static FightManager instance = null; // Allows other scripts to call functions from FightManager.

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
    }

    public void playerAttack()
    {
        // Si el enemigo se está defendiendo es un contraataque
        if (enemy.State == 5)
        {
            transform.position += new Vector3(-0.5f, 0, 0);
        }
        else // Si no, el ataque tiene éxito
        {
            //GetComponent<Rigidbody2D>().AddForce(Vector2.right);
            transform.position += new Vector3(0.5f, 0, 0);
        }
    }

    public void enemyAttack()
    {
        // Si el jugador se está defendiendo es un contraataque
        if (player.State == 5)
        {
            transform.position += new Vector3(0.5f, 0, 0);
        }
        else // Si no, el ataque tiene éxito
        {
            transform.position += new Vector3(-0.5f, 0, 0);
        }
    }

}
