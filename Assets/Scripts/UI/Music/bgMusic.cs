using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bgMusic : MonoBehaviour
{
    private static bgMusic backgroundMusic;
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = 1;
    }

    private void Awake()
    {
        if(backgroundMusic == null)
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }
        else
        {
            Destroy(gameObject);
        }
    }

}


