using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviour : MonoBehaviour
{
    //Add a reference to an enemy script
    void Awake()
    {
        //Get the enemy script component for this specific enemy to get the data
    }
    public void RunMovementBehaviour(GameObject parent)
    {
        //Run the behaviour by calling this every update
    }

    //You might need to use a coroutine for some behaviours, but in general they will run every update when in the proper state

    //Example: This is for the "Chase" behaviour essentially. What the enemy does before they attack
}
