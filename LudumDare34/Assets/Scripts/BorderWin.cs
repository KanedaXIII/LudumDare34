using UnityEngine;
using System.Collections;

public class BorderWin : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag=="Enemy")
        {
            FightManager.instance.combatWin();
        }
        else if (coll.gameObject.tag=="Player")
        {
            FightManager.instance.combatLose();
        }
    }

}
