using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour
{
    /* NOTES: Prefabs of enemies
            All attack behaviors are mixed and matched between enemies
            EX: Shambler has a movement script called Shamble, which is a movementBehavior component
            Has 2 components attached (MB and AB)- if done properly, this will allow us to mix and match between enemies and create new types
    */

    //Add a reference to an enemy script
    [SerializeField] EnemyBehavior eB;

    void Awake()
    {
        //Get the enemy script component for this specific enemy to get the data
        eB = GetComponent<EnemyBehavior>();
    }
    
    public virtual void RunAttackBehaviour(GameObject parent)
    {
        //Run the behaviour by calling this every update
    }

    //You might need to use a coroutine for some behaviours, but in general they will run every update when in the proper state

    //Example: If the enemy has a unique attack behaviour, this is where it would go, like stepping back or taking a shot from their position
    //Shooting is an attack behaviour. You might need to customize the triggers per enemy, but generally you can have the attack behaviour run however you want it.
}
