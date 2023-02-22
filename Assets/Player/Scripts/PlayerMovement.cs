using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;
    public GameObject deathCam;

    private Vector3 playerVelocity;
    private bool groundedPlayer = true;
    private float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVel;

    private bool check;
    public static bool canMove;

    [SerializeField]
    private Transform cameraTransform;

    public List<Collider> RagdollParts = new List<Collider>();
    public List<Rigidbody> bodies = new List<Rigidbody>();



    void Awake()
    {
        //SetRagdollParts();
        //TurnOffRagdoll();
        deathCam.SetActive(false);
        canMove = true;
    }
    private void Start()
    {
        //controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        DoorInteract();
        Run();
    }
    void FixedUpdate()
    {
        if(canMove)
        {
            Movement();
            Jump();
        }
    }

    void Movement()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;
        //move = Quaternion.AngleAxis(cameraTransform.rotation.eulerAngles.y, Vector3.up) * move;

        if (move.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(move.x,move.z) * Mathf.Rad2Deg + cameraTransform.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVel, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0f,angle,0f);

            Vector3 moveDir = Quaternion.Euler(0f,targetAngle,0f) * Vector3.forward;
            controller.Move(moveDir.normalized * Time.deltaTime * playerSpeed);
            anim.SetTrigger("walk");
        }
        else
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
        // if (Input.GetButtonDown("Jump") && groundedPlayer)
        // {
        //     playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        // }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void Run()
    {
        if(Input.GetButtonDown("Fire3"))
        {
            playerSpeed = 5f;
            anim.speed = 1.2f;
        }
           
        if(Input.GetButtonUp("Fire3"))
        {
            playerSpeed = 2f;
            anim.speed = 1f;
        }
    }

    IEnumerator DoorInteraction()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(check)
            {
                Debug.Log("DoorInteraction!!!");
                check = false;
                DoorMechanics.check = true;
                yield return new WaitForSeconds(0.1f);
                DoorMechanics.check = false;
            }
        }
    }
    void DoorInteract()
    {
        StartCoroutine(DoorInteraction());   
    }

    void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Door")
        {
            check = true;
        }
    }

    void SetRagdollParts()
    {
        Collider[] colliders = this.gameObject.GetComponentsInChildren<Collider>();

        foreach(Collider c in colliders) 
        {
            if(c.gameObject != this.gameObject)
            {
                c.isTrigger = true;
                RagdollParts.Add(c);
            }
        }
    }

    private void TurnOffRagdoll()
    {

        Rigidbody[] rigidbody = this.gameObject.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody b in rigidbody)
        {
            if(b.gameObject != this.gameObject)
            {
        
                bodies.Add(b);
            }
        }
        foreach (Rigidbody b in bodies)
        {
            b.isKinematic = true;
            b.detectCollisions = false;
        }

    }
    
    public void turnonnragdoll()
    {
        //playerrigidbody.useGravity =false;
        //playerrigidbody.velocity = Vector3.zero;
        //this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
        anim.enabled = false;
        anim.avatar = null;

        foreach (Collider c in RagdollParts)
        {
            c.isTrigger = false;
            c.attachedRigidbody.velocity = Vector3.zero;
        }
        foreach (Rigidbody b in bodies)
        {
            b.isKinematic = false;
            b.detectCollisions = true;
        }

    }

    public void TurnOnRagdoll()
    {
        //rb.useGravity = false;
        //rb.velovity = Vector3.zero;
        this.gameObject.GetComponent<CharacterController>().enabled = false;
        anim.enabled = false;
        anim.avatar = null;
        foreach(Collider c in RagdollParts) 
        {
            c.isTrigger = true;
            c.attachedRigidbody.velocity = Vector3.zero;
        }
    }

    public void Death()
    {
        StartCoroutine(StartDeath());
    }

    IEnumerator StartDeath()
    {
        canMove = false;
        deathCam.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        anim.SetTrigger("death");
        // yield return new WaitForSeconds(5f);
        // anim.SetTrigger("idle");
    }
}
