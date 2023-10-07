using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource introBackgroundMusic;
    public AudioSource normalStateBackgroundMusic;

    void Start()
    {
        introBackgroundMusic.Play();
    }

    void Update()
    {
        if (!introBackgroundMusic.isPlaying && !normalStateBackgroundMusic.isPlaying)
        {
            // Your logic to determine when the transition should happen
            /* Your condition for the transition */
            {
                introBackgroundMusic.Stop();
                normalStateBackgroundMusic.Play();
            }
        }
    }
}