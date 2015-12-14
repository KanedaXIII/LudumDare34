﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SumoFighterController : MonoBehaviour
{
	public float bellyScale = 1.0f;
	public Transform bellyTransform;
	public Transform chestTransform;
    public GameObject PartAbsorb;
    public int contF;
    public Text counter;
    string loadedScene;

    void Start()
    {
        this.bellyScale=GameManager.instance.bellyScale;
        setChest();
        loadedScene=SceneManager.GetActiveScene().name;
    }

	void Update()
	{
        // Restamos el valor al contador de la pantalla
        counter.text = (5 - contF).ToString();

		this.bellyTransform.localScale = new Vector3(this.bellyScale, this.bellyScale);

        if (loadedScene=="Restaurant")
        {
            if (GameManager.instance.bellyScale>bellyScale)
            {
                setChest();
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
            {
                PartAbsorb.GetComponent<Animator>().Play("Activate");
            }
            if (contF==5)
            {
                GameManager.instance.ChangeScene("Tatami");
            }
            
        }

	}

    public void setChest()
    {
        bellyScale=GameManager.instance.bellyScale;
        this.chestTransform.localScale = Vector3.one / this.bellyScale;
    }
}