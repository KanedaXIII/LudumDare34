using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Sumo : MonoBehaviour {

    public float strength;
    public float resistance;
    public float defense;

    Scene sceneLoaded;

    // Use this for initialization
    void Start () {
        sceneLoaded= SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
        if (sceneLoaded.name=="Restaurant")
        {
            if (Input.GetKeyDown(KeyCode.A)||Input.GetKeyDown(KeyCode.S)){

            }
        }else if (sceneLoaded.name == "Tatami")
        {

        }
	}
}
