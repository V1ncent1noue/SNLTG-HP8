using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    private PlayerInputHandler InputHandler;
    private Attribute Attribute;
    [SerializeField] private PlayerData Data;
    public Rigidbody2D RigidBody { get; private set; }
    // private Vector2 MoveDirection;
    private Animator Animator;
    private int isFacingRight = 1; 
    public HealthBar HealthBar;


    private void Awake()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
        Attribute = GetComponent<Attribute>();
        RigidBody = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();

        //Set attribute
        Attribute.MaxHealth = Data.MaxHealth;
        Attribute.Health = Data.Health;
        Attribute.Attack = Data.Attack;
        Attribute.MovementSpeed = Data.MovementSpeed;
        //Set health bar
        HealthBar.SetMaxHealth(Attribute.MaxHealth);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        CheckDied();
        CheckMovement();
        CheckFlip();
        Move();
    }
    private void CheckMovement()
    {
        
        if (InputHandler.MovementInput != Vector2.zero)
        {
            SetAnimationBool("isMoving", true);
        }
        else
        {
            SetAnimationBool("isMoving", false);
        }
        if (InputHandler.AttackInput != false)
        {
            SetAnimationBool("isAttacking", true);
        }
        else
        {
            SetAnimationBool("isAttacking", false);
        }
    }

    private void Move()
    {
        RigidBody.velocity = InputHandler.MovementInput * Attribute.MovementSpeed;
    }

    //Check functions
    private void CheckFlip()
    {
            if ((InputHandler.InputX > 0 && isFacingRight == -1) || (InputHandler.InputX < 0 && isFacingRight == 1))
        {
            Flip();
        }
    }
        private void Flip()
    {
        isFacingRight = isFacingRight * -1;
        transform.Rotate(0f, 180f, 0f);
    }
    private void CheckDied() {
        if (Attribute.Health <= 0) {
            Attribute.MovementSpeed = 0;
            LevelManager.Lose();
        }
        HealthBar.SetHealth(Attribute.Health);
    }
    //Set functions 
    //Set animation bools by name
    public void SetAnimationBool(string name, bool value)
    {
        Animator.SetBool(name, value);
    }


}
