using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioClip[] clips; // Drag and add audio clips in the inspector
    AudioSource audioSource;
    int currentIndex = 0; // Keep track of the current audio clip index

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayNextSound();
    }

    public void ChangeTheSound(int clipIndex)
    {
        // Check if the given index is valid
        if (clipIndex >= 0 && clipIndex < clips.Length)
        {
            currentIndex = clipIndex;
            PlayNextSound();
        }
        else
        {
            Debug.LogWarning("Invalid clip index.");
        }
    }

    void PlayNextSound()
    {
        // Stop any currently playing audio
        audioSource.Stop();

        // Set the next audio clip
        audioSource.clip = clips[currentIndex];

        // Play the audio
        audioSource.Play();

        // Subscribe to the callback for when the current audio clip finishes
        StartCoroutine(WaitForSoundToFinish());
    }

    IEnumerator WaitForSoundToFinish()
    {
        // Wait for the current audio clip to finish playing
        yield return new WaitForSeconds(audioSource.clip.length);

        // Increment the index to play the next sound (e.g., for looping)
        currentIndex++;

        // Check if we've reached the end of the array and loop back to the start
        if (currentIndex >= clips.Length)
        {
            currentIndex = 0;
        }

        // Play the next sound
        PlayNextSound();
    }
}