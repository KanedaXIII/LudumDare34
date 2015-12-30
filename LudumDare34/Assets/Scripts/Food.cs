using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

    public string nameFood;
    public int valueStrength;
    public int valueResistance;
    public int valueDefense;
    public bool isTake=false;
    public AudioClip eatSound;

	// Use this for initialization
	void Start () {
       
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D)) && isTake)
        {
            SoundManager.instance.PlaySingle(eatSound);
            setSumStats();
            GameObject.FindGameObjectWithTag("Player").GetComponent<SumoFighterController>().contF++;
            Destroy(this.gameObject);
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

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag=="foodDest")
        {
            Destroy(this.gameObject);
        }
       
    }

    public void setSumStats()
    {
       
        GameManager.instance.BonusStrength+=this.valueStrength;

        GameManager.instance.BonusDefense+= this.valueDefense;

        GameManager.instance.BonusResistance+=this.valueResistance;

        GameManager.instance.bellyScale += 0.005f;
        
    }
}

