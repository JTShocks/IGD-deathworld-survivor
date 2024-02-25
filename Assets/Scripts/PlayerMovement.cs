using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // TO DO: Sync movement to animation controller, indicate when player is damaged with color change

    [Header("Movement")] // Variables related to the player's movement
    private float moveSpeed = 10f; // How fast the player goes
    
    private float horizontalInput; //Player's horizontal input
    private float verticalInput; //Player's vertical input

    private Vector3 moveDirection; // Vector3 to say in which direction the player will move
    private Rigidbody2D rb; // Rigidbody of the player used for movement

    [SerializeField] Animator m_Animator; // Player animator

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        m_Animator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerInput();
    }

    void PlayerInput() 
    {
        
        horizontalInput = Input.GetAxisRaw("Horizontal"); // WASD and/or Arrow Keys used for player input
        verticalInput = Input.GetAxisRaw("Vertical"); // WASD and/or Arrow Keys used for player input

        bool hasHorizontalInput = !Mathf.Approximately(horizontalInput, 0f);
        bool hasVerticalInput = !Mathf.Approximately(verticalInput, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;
        m_Animator.SetBool("IsWalking", isWalking); // Sets Animator's bool condition depending on input
    }

    void ApplyPlayerMovement() 
    {
        
    }
}
