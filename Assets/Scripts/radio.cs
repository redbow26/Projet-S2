using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class radio : MonoBehaviour
{
    private bool isPlaying = false;
    public AudioClip[] soundtrack;
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }


    public void play()
    {
        if (!isPlaying)
        {
            AudioClip sound = soundtrack[Random.Range(0, soundtrack.Length)];
            while (audioSource.clip == sound)
            {
                sound = soundtrack[Random.Range(0, soundtrack.Length)];
            }
            if (sound.name == "Gotta Catch Em All") audioSource.volume = 0.1f;
            else audioSource.volume = 0.2f;
            audioSource.clip = sound;
            audioSource.Play();
            isPlaying = true;
        }
    }

    public void stop()
    {
        if (isPlaying && audioSource.isPlaying)
        {
            audioSource.Stop();
            isPlaying = false;
        }
        else
        {
            play();
        }
    }
}
