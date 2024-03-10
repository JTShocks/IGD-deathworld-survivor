using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.U2D;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(PlayerInput))]

public class PlayerController : CharacterBase, IDamagable
{
    PlayerInput input;
    public static Transform playerTransform;
    InputAction moveAction;
    float immunityTimer = 0;
    [SerializeField]
    float imunnityTime, flickerRate;
    bool canMove;

    protected override void Awake()
    {
        playerTransform=transform;
        base.Awake();
        input = GetComponent<PlayerInput>();
        moveAction = input.actions["Move"];

    }
    // Start is called before the first frame update
    void Start()
    {
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
        rb.MovePosition((Vector2)this.transform.position + moveDir * speed * (canMove?1:0) * Time.fixedDeltaTime);
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

    public override void TakeDamage(float damage, DamageType damageType = null)
    {
        if (immunityTimer > 0)
        {
            return;
        }
        immunityTimer = imunnityTime;
        StartCoroutine(Flicker());
        base.TakeDamage(damage, damageType);
        //throw new System.NotImplementedException();
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

    public void Trap(bool isTrapped = true) => canMove = !isTrapped;
    
}
