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
        //CheckForPlayer();
        // TO DO: Ask Jacob for implementation with EnemyBehavior switch statement and how to change states to attacking
        // Ranged Attacks use physics with Vector math like the player movement, so use FixedUpdate.
                
        if (PlayerController.playerTransform != null)
        {

        }
    }

    // Note: void OnDestroy() is a method that calls something when the object is destroyed-- this can be helpful for the Polluter and/or an Exploder.
    private void OnDestroy()
    {
        
    }

    /*void CheckForPlayer()
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
    } */



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // FixedUpdate is called once per physics update
    void FixedUpdate()
    {
        
    }
}
