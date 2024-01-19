using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private Animator Animator;
    private Attribute Attribute;
    [SerializeField] private float specialAttackCD;
    private float specialAttackCDTimer;
    private float currentMovementSpeed;
    public HealthBar BossHealthBar;


    // Start is called before the first frame update
    void Awake()
    {
        Animator = GetComponent<Animator>();
        Attribute = GetComponent<Attribute>();
        UIManager.EnableBossHealthBar();
        BossHealthBar = GameObject.FindGameObjectWithTag("BossHealthBar").GetComponent<HealthBar>();
        BossHealthBar.SetMaxHealth(Attribute.MaxHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CheckDied();
        specialAttack();
    }

    private void specialAttack()
    {
        if (Attribute.Health <= Attribute.MaxHealth * 0.5f)
        {
            if (specialAttackCDTimer <= 0)
            {
                Animator.SetBool("UsingSpecialAttack", true);
                specialAttackCDTimer = specialAttackCD;
                currentMovementSpeed = Attribute.MovementSpeed;
                Attribute.MovementSpeed = 0;
            }
            else
            {
                specialAttackCDTimer -= Time.deltaTime;
            }
        }
    }
    private void stopSpecialAttack()
    {
        Animator.SetBool("UsingSpecialAttack", false);
        Attribute.MovementSpeed = currentMovementSpeed;
    }

    private void CheckDied()
    {
        BossHealthBar.SetHealth(Attribute.Health);
        if (Attribute.Health <= 0)
        {
            LevelManager.Win();
        }
    }
}
