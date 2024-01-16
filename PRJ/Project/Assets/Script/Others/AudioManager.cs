using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource BGMAudioSource;
    [SerializeField] private AudioSource SFXAudioSource;

    public void playAudioClip(AudioClip audioClip)
    {
        SFXAudioSource.PlayOneShot(audioClip);
    }
}
