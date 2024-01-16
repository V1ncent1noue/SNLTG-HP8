using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip AttackAudioClip;
    public AudioClip AttackHitAudioClip;
    public AudioClip DeathAudioClip;
    public AudioClip HitAudioClip;
    public AudioClip SpecialAttackHitAudioClip;

    private AudioManager audioManager;

    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }

    void PlayAttackAudioClip()
    {
        audioManager.playAudioClip(AttackAudioClip);
    }
}
