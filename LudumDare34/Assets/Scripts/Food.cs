using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

    public string nameFood;
    public int valueStrength;
    public int valueResistance;
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

    void OnTriggerEnter2D(Collider2D other)
    {  
        if (other.gameObject.tag=="canTake")
        {
            this.isTake = true;
            Debug.Log("Activado");
        }else if (other.gameObject.tag=="cantTake")
        {
            this.isTake = false;
            Debug.Log("Desactivado");
        }
    }
    public void setSumStats()
    {
       
        GameManager.instance.BonusStrength+=this.valueStrength;

        GameManager.instance.BonusDefense+= this.valueDefense;

        GameManager.instance.BonusResistance+=this.valueResistance;
        
    }
}

