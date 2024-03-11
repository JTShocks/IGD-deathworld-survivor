using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetection : MonoBehaviour
{
    EnemyBehavior eB;
    Collider2D circleDetector;

    // NOTES: If we are running the attacks and movements SEPARATELY, use a Switch statement in eB
    // Think of it as a fancier version of "if-else" statements
    
    // SETUP: Circle Trigger to detect a GameObject in its own transform and the EnemyBehavior in parent (GetComponentInParent)
    // That influences the switch statement where if the GameObject is detected through OnTriggerEnter/Exit, the statement will switch cases

    // Start is called before the first frame update
    void Awake()
    {
        eB = GetComponentInParent<EnemyBehavior>();
        circleDetector = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            eB.ChangeEnemyState(EnemyBehavior.EnemyState.Attack);
            Debug.Log("PLAYER IN RANGE: STATE CHANGED TO ATTACK");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            eB.ChangeEnemyState(EnemyBehavior.EnemyState.Move);
            Debug.Log("PLAYER IN RANGE: STATE CHANGED TO MOVE");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
