using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] audioClips;
    private AudioSource audioSource;
    public GameState State;


    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        PlayClip(0);
    }

    public void PlayClip(int clipIndex)
    {
        if (clipIndex >= 0 && clipIndex < audioClips.Length)
        {

            audioSource.Stop(); 
            audioSource.clip = audioClips[clipIndex];
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("Invalid clip index! Please provide a valid index.");
        }

    }

    public void PlayGameOverClip()
    {
        if (State == GameState.GameOver)
        {
            PlayClip(0); 
        }
    }




}
