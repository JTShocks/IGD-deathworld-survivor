using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerController : MonoBehaviour, IDamagable
{
    PlayerInput input;
    Rigidbody2D rb;
    Animator animator;
    InputAction moveAction;
    [SerializeField]
    float speed,accel;
    Vector2 moveDir;
    SpriteRenderer spriteRenderer;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        input = GetComponent<PlayerInput>();
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        moveAction = input.actions["Move"];
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FixedUpdate()
    {
        moveDir = moveAction.ReadValue<Vector2>();
        rb.MovePosition((Vector2)this.transform.position + moveDir * speed*Time.fixedDeltaTime);
        animator.SetFloat("MoveValue", moveDir.magnitude/2f);
        if (moveDir.x<0)
        {
            //spriteRenderer.flipY = true;
            animator.SetBool("FlipSprite",false);

        }
        else if (moveDir.x > 0)
        {
            //spriteRenderer.flipY = false;
            animator.SetBool("FlipSprite", true);
        }
    }

    public void TakeDamage(int damage)
    {
        throw new System.NotImplementedException();
    }
}
