﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class SumoFighterController : MonoBehaviour
{
	public float bellyScale = 1.0f;
	public Transform bellyTransform;
	public Transform chestTransform;

    string loadedScene;

    void Start()
    {
        this.bellyScale=GameManager.instance.bellyScale;
        setChest();
        loadedScene=SceneManager.GetActiveScene().name;
    }

	void Update()
	{
		this.bellyTransform.localScale = new Vector3(this.bellyScale, this.bellyScale);

        if (loadedScene=="Restaurant")
        {
            if (GameManager.instance.bellyScale>bellyScale)
            {
                setChest();
            }
            
        }

	}

    public void setChest()
    {
        bellyScale=GameManager.instance.bellyScale;
        this.chestTransform.localScale = Vector3.one / this.bellyScale;
    }
}