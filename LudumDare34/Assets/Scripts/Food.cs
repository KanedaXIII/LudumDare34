using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

    public string nameFood;
    public int valueStrength;
    public int valueResistence;
    public int valueDefense;
    public bool isTake=false;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.S))
        {
            setSumStats();
            Destroy(this);
        }
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag=="canTake")
        {
            this.isTake = true;
        }else if (coll.gameObject.tag=="cantTake")
        {
            this.isTake = false;
        }
    }
    public void setSumStats()
    {
        /*
       
        GameManager.instance.BonusStrength+=this.valueStrength;

        GameManager.instance.BonusDefense+= this.valueDefense;

        GameManager.instance.BonusResistence+=this.valueResistence;
        */
    }
}

