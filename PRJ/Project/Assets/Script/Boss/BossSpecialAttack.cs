using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpecialAttack : MonoBehaviour
{

    private AudioManager audioManager;
    void Start()
    {
        audioManager = GameObject.FindGameObjectWithTag("AudioManager").GetComponent<AudioManager>();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        
            Attribute attackerAttribute = GetComponentInParent<Attribute>();
            Attribute victimAttribute = collision.GetComponent<Attribute>();
            AudioHandler audioHandler = GetComponentInParent<AudioHandler>();
            if (attackerAttribute != null && victimAttribute != null)
            {
                audioManager.playAudioClip(audioHandler.SpecialAttackHitAudioClip);
                victimAttribute.TakeDamage(attackerAttribute.Attack/20);
            
        }
    }
}
