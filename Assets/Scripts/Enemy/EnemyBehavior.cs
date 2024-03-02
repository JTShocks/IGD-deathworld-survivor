using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyBehavior : MonoBehaviour
{
      //Enemy tracks to the player constantly

    Rigidbody2D body;
    [SerializeField] float moveSpeed;
    [SerializeField] float trackingRadius;
    Transform targetTransform;
    [SerializeField] LayerMask activeLayer;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();

    }

    void FixedUpdate()
    {
        CheckForPlayer();
        if(targetTransform != null)
        {
            MoveTo(targetTransform);
        }

    }

    void MoveTo(Transform target)
    {
        //Moves to the target position. Flexible to work with any location we want should we want a distractor object or something similar
        Vector2 moveVector = transform.position - target.position;
        body.AddForce(moveVector * moveSpeed);
    }

    void CheckForPlayer()
    {
        //Will check around itself for objects on a certain layer. 
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, trackingRadius, activeLayer);
        foreach(Collider2D hit in hits)
        {
            if(hit.CompareTag("Player"))
            {
                targetTransform = hit.transform;
            }
        }
    }




}
