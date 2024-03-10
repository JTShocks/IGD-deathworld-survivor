using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBehaviour : MonoBehaviour
{

    //Add a reference to an enemy script
    void Awake()
    {
        //Get the enemy script component for this specific enemy to get the data
    }
    public void RunAttackBehaviour(GameObject parent)
    {
        //Run the behaviour by calling this every update
    }

    //You might need to use a coroutine for some behaviours, but in general they will run every update when in the proper state

    //Example: If the enemy has a unique attack behaviour, this is where it would go, like stepping back or taking a shot from their position
    //Shooting is an attack behaviour. You might need to customize the triggers per enemy, but generally you can have the attack behaviour run however you want it.
}
