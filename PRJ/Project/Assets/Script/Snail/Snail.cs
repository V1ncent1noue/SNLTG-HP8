using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snail : MonoBehaviour
{

    private Rigidbody2D RigidBody;
    private Attribute Attribute;
    private Animator Animator;
    private int IsFacingRight = -1;
    private GameObject playerGameObject;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private Transform AttackRange;
    public LayerMask playerLayer;
    private bool isAttackable;
    // Start is called before the first frame update
    void Start()
    {
        RigidBody = GetComponent<Rigidbody2D>();
        playerGameObject = GameObject.FindWithTag("Player");
        Animator = GetComponent<Animator>();
        Attribute = GetComponent<Attribute>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckDied();
        if(!isAttackable)
        MoveToPlayer();
        if(Attribute.MovementSpeed != 0)
        CheckFlip();
        AttackableCheck();
    }

    //Move find player via "Player" tag and move towards them
    void MoveToPlayer()
    {
        Vector2 direction = playerGameObject.transform.position - transform.position;
        RigidBody.velocity = direction.normalized * Attribute.MovementSpeed;
    }

    private void Flip()
    {
        IsFacingRight = IsFacingRight * -1;
        transform.Rotate(0f, 180f, 0f);
    }
    private void CheckFlip()
    {
        if (RigidBody.velocity.x > 0 && IsFacingRight == -1)
        {
            Flip();
        }
        else if (RigidBody.velocity.x < 0 && IsFacingRight == 1)
        {
            Flip();
        }
    }

    float waitTime = 0.5f;
    private void CheckDied() {
        if (Attribute.Health <= 0) {
            waitTime -= Time.deltaTime;
            Attribute.MovementSpeed = 0;
            Attribute.TakeDamage(0);
            if (waitTime <= 0)
            Destroy(gameObject);
        }
    }
    private void AttackableCheck()
    {
        if(Physics2D.OverlapCircle(AttackRange.position, attackRange, playerLayer))
        {
            isAttackable = true;
            Animator.SetBool("isAttackable", true);
            RigidBody.velocity = Vector2.zero;
        }
        else
        {
            isAttackable = false;
            Animator.SetBool("isAttackable", false);
        }
    }
    public void SetAnimationBool(string name, bool value)
    {
        Animator.SetBool(name, value);
    }

    
}
