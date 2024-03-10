using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shamble : MovementBehaviour
{

    Transform target;
    [SerializeField] float moveSpeed;
    [SerializeField] float trackingRadius;
    [SerializeField] LayerMask activeLayer;

    public override void RunMovementBehaviour(GameObject parent)
    {

        CheckForPlayer();
        if (target != null)
        {
            Rigidbody2D body = parent.GetComponent<Rigidbody2D>();
            Vector2 moveVector = target.position - transform.position;
            body.position += moveVector.normalized * moveSpeed * Time.fixedDeltaTime;            
        }

        // base.RunMovementBehaviour(parent);
    }

    void CheckForPlayer()
    {
        //Will check around itself for objects on a certain layer. 
        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, trackingRadius, activeLayer);
        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag("Player"))
            {
                target = hit.transform;
            }


        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
