using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapEntity : MonoBehaviour
{
    [SerializeField] float trapTime;
    float trapTimeLeft;
    PlayerController player;

    private void Update()
    {
        if(trapTime > 0)
        {
            trapTime -= Time.deltaTime;
            if(trapTime <= 0)
            {
                trapTimeLeft = 0;
                player.Trap(false);
                player = null;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        player = other.GetComponent<PlayerController>();
        if (player == null) return;
        player.Trap();
        trapTimeLeft = trapTime;
    }
}
