using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieSoundEffects : MonoBehaviour
{
    AudioSource audioData;

    public AudioClip footStepClip;
    public float volume = 0.5f;
    void Start()
    {
        audioData = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void PlayFootSteps()
    {
        audioData.PlayOneShot(footStepClip, volume);

    }
}
