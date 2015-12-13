using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {

    public float strength;
    public float resistance;
    public float defense;

    public float timeToResponse;
    public float timeR;

    public int contAt;

    public string side;

    // Use this for initialization
    void Start () {
        timeR = timeToResponse;
	}
	
	// Update is called once per frame
	void Update () {

        this.timeR -= Time.deltaTime;
        if (timeR==0)
        {
            int rand = Random.Range(1, 4);
            RandomMove(rand);
            timeR = timeToResponse;
        }


    }

    void RandomMove(int r)
    {
        switch (r)
        {
            case 1:
                normalAttackMove();
                break;
            case 2:
                superAttackMove();
                break;
            case 3:
                defenseMove();
                break;
        }
    }

    void counterMove()
    {

    }

    void superAttackMove()
    {

    }

    void normalAttackMove()
    {

    }

    void defenseMove()
    {

    }
}
