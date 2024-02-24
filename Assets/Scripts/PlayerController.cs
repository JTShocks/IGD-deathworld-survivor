using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D;

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
    float immunityTimer = 0;
    [SerializeField]
    float imunnityTime,flickerRate;
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        input = GetComponent<PlayerInput>();
        rb=GetComponent<Rigidbody2D>();
        animator=GetComponent<Animator>();
        moveAction = input.actions["Move"];
    }
    // Start is called before the first frame update
    void Start()
    {
        TakeDamage(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (immunityTimer > 0)
        {
            immunityTimer-= Time.deltaTime;
        }
        
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
        immunityTimer = imunnityTime;
        StartCoroutine(Flicker());
        throw new System.NotImplementedException();
    }
    IEnumerator Flicker()
    {
        print("working");
        while (immunityTimer > 0)
        {

            spriteRenderer.enabled = !spriteRenderer.enabled;

            yield return new WaitForSeconds(1/flickerRate);
           

        }
        spriteRenderer.enabled = true;

    }
}
