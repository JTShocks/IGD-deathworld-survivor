using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyBehavior : MonoBehaviour
{

    public enum EnemyState{
        Idle,
        Move,
        Attack
    }
    //Enemy tracks to the player constantly
    protected MovementBehaviour movementBehaviour;
    protected AttackBehaviour attackBehaviour;

    public EnemyState state;

    Rigidbody2D body;
    [SerializeField] float moveSpeed;
    [SerializeField] float trackingRadius;
    Transform targetTransform;
    [SerializeField] LayerMask activeLayer;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        movementBehaviour = GetComponent<MovementBehaviour>();
        attackBehaviour = GetComponent<AttackBehaviour>();
    }
    
    public virtual void Update()
    {
        switch(state)
        {
           //Switch statement in the update for running the various states, if needed, for anything that should happen each frame.
           //Copy whatever your need into the fixed update, most likely regarding movement.
            //Feel free to add states if you need them, but typically this is where the states will go.
            case EnemyState.Idle:
            break;
            case EnemyState.Move:
            break;
            case EnemyState.Attack:
                attackBehaviour.RunAttackBehaviour(gameObject);
            break;
        }
    }

    void FixedUpdate()
    {
        if (state == EnemyState.Move) 
        {
            movementBehaviour.RunMovementBehaviour(gameObject);
        }

    }

    void MoveTo(Transform target)
    {
        //Moves to the target position. Flexible to work with any location we want should we want a distractor object or something similar
        Vector2 moveVector = target.position - transform.position;
        body.position += moveVector.normalized * moveSpeed * Time.fixedDeltaTime;
    }    

    public void ChangeEnemyState(EnemyState newState)
    {
        state = newState;
        switch(state)
        {
            //Switch statement for changing the state. This should fire only once. Use this to trigger anything that happens when the state is changed.
            //Feel free to add states if you need them, but typically this is where the states will go.
            case EnemyState.Idle:
            break;
            case EnemyState.Move:
            break;
            case EnemyState.Attack:
            break;
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Player")) 
        {
            collision.transform.GetComponent<IDamagable>().TakeDamage(2f);            
        }
    }

}
