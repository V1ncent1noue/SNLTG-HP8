using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Attack : MonoBehaviour
{
    private AudioManager audioManager;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attribute attackerAttribute = GetComponentInParent<Attribute>();
        Attribute victimAttribute = collision.GetComponent<Attribute>();
        AudioHandler audioHandler = GetComponentInParent<AudioHandler>();
        if (attackerAttribute != null && victimAttribute != null)
        {
            audioManager.playAudioClip(audioHandler.AttackHitAudioClip);
            victimAttribute.TakeDamage(attackerAttribute.Attack);
        }
    }
}
