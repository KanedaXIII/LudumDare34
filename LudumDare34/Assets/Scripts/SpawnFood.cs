using UnityEngine;
using System.Collections;

public class SpawnFood : MonoBehaviour {

    public GameObject[] Food;

    public float timeT = 180;
    float timeR;
    // Use this for initialization
    void Start () {
        timeR = timeT;
	}
	
	// Update is called once per frame
	void Update () {
        NewFood();
        this.timeR -= Time.deltaTime;
        if (timeR==0)
        {
            NewFood();
            timeR = timeT;
        }
    }

    void NewFood()
    {
        int randomInt = Random.Range(0, Food.Length);
        GameObject nfood;
        nfood = (GameObject)Instantiate(Food[randomInt], transform.position, Quaternion.identity);

    }
}
