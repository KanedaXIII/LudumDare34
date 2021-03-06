﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class stopWatch : MonoBehaviour {


    public Text stopWatchText;

    public float timeT = 180;

    private int min, sec, mSec;

    public Color alertColor;

    public AudioSource lastSeconds;

    private bool lastSecondsPlayed = false;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        stopWatchF(timeT);
    }

    public void stopWatchF(float timeTe)
    {
        this.timeT -= Time.deltaTime;

        if (timeTe > 0)
        {
            min = (int)timeTe / 60;

            sec = (int)timeTe % 60;

            mSec = (int)(timeTe * 100) % 100;

            //Debug.Log(min + " : " + sec + " : " + mSec);

        }

        if (sec == 5)
        {
            stopWatchText.color = alertColor;
            if (!lastSecondsPlayed)
            {
                lastSeconds.Play();
                lastSecondsPlayed = true;
            }
        }

        if (sec == 1)
        {

            Invoke("blockGame", 2f);

        }
        //stopWatchText.text= min + " : " + sec + " : " + mSec;
        stopWatchText.text = sec.ToString();
    }

    private void blockGame()
    {
        /*
        GameManager.Instance.Block = true;
        GameManager.Instance.SetGuiItemsEnabled("EndGame", true);
        GameManager.Instance.UpdateTotalScore();
        */
    }
}
