using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;
    private Vector3 playerVelocity;
    private bool groundedPlayer = true;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;

    [SerializeField]
    private Transform cameraTransform;


    private void Start()
    {
        //controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        
    }
    void FixedUpdate()
    {
        Movement();
        Jump();
    }

    void Movement()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);
        move = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * move;

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            anim.SetTrigger("walk");
        }
        else if(move == Vector3.zero )
        {
            anim.SetTrigger("notWalk");
        }
    }
    
    void Jump()
    {
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
