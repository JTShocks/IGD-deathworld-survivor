using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ranged : AttackBehaviour
{
    Transform target;
    // [SerializeField] float moveSpeed;
    [SerializeField] float trackingRadius;
    [SerializeField] LayerMask activeLayer;

    public virtual void RunAttackBehaviour(GameObject parent)
    {
        //Run the behaviour by calling this every update
        CheckForPlayer();
        
        if (PlayerController.playerTransform != null)
        {

        }
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
                Debug.Log("Player has been attacked!");
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
