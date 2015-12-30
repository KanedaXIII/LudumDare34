using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource efxSource;           // Drag a reference to the audio source which will play the sound effects.
    public AudioSource efxSource2;
    public AudioSource music;               // Drag a reference to the audio source which will play the music.
    public static SoundManager instance = null; // Allows other scripts to call functions from SoundManager.

    void Awake()
    {
        // Check if there is already an instance of SoundManager
        if (instance == null)
            //if not, set it to this.
            instance = this;
        //If instance already exists:
        else if (instance != this)
            //Destroy this, this enforces our singleton pattern so there can only be one instance of SoundManager.
            Destroy(gameObject);

        //Set SoundManager to DontDestroyOnLoad so that it won't be destroyed when reloading our scene.
        DontDestroyOnLoad(gameObject);
    }

    //Used to play single sound clips.
    public void PlaySingle(AudioClip clip)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource.clip = clip;

        //Play the clip.
        efxSource.Play();
    }

    public void PlaySingleDelay(AudioClip clip, float delay)
    {
        efxSource.clip = clip;
        efxSource.PlayDelayed(delay);
    }

    //Used to play single sound clips.
    public void PlaySingle2(AudioClip clip)
    {
        //Set the clip of our efxSource audio source to the clip passed in as a parameter.
        efxSource2.clip = clip;

        //Play the clip.
        efxSource2.Play();
    }

    public void PlaySingleDelay2(AudioClip clip, float delay)
    {
        efxSource2.clip = clip;
        efxSource2.PlayDelayed(delay);
    }

    public void PlayMusic(AudioClip clip)
    {
        music.clip = clip;
        music.Play();
    }

}