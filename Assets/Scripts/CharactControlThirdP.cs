using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactControlThirdP : MonoBehaviour
{
    public float Speed;
    public float jumpForce;
    public Rigidbody theRB;
    public float gravityScale;

    private int jumps;

    private void Update()
    {
        theRB = GetComponent<Rigidbody>();
        PlayerMovements();
    }

    void PlayerMovements()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 playerMove = new Vector3(horizontal, 0, vertical).normalized * Speed * Time.deltaTime;
        jumps = 0;

        if (Input.GetKeyDown("space") && jumps < 1)
        {
            theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
            jumps++;
        }
        transform.Translate(playerMove, Space.Self);


    }
 }

/*    //public Rigidbody theRB;

    //public CharacterController controller;//NEW
    //public float gravityScale;//NEW

    private void Update()
    {
        //theRB = GetComponent<Rigidbody>();
        //controller = GetComponent<CharacterController>();//NEW
        PlayerMovements();
    }

    void PlayerMovements()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 playerMove = new Vector3(horizontal, 0, vertical).normalized * Speed * Time.deltaTime;

        if (Input.GetKeyDown("space"))
        {
            //theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
            playerMove.y = jumpForce;
        }

        //playerMove.y = playerMove.y + (Physics.gravity.y * gravityScale);
        transform.Translate(playerMove, Space.Self);


/*--Mauvais Mouvements--
       public float moveSpeed;
       public Rigidbody theRB;
       public float jumpForce;

       private void Start()
       {
           theRB = GetComponent<Rigidbody>();
       }

       private void Update()
       {
           theRB.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, theRB.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
           if (Input.GetKeyDown("space"))
           {
               theRB.velocity = new Vector3(theRB.velocity.x, jumpForce, theRB.velocity.z);
           }
       }*/

/*--NO DIAGONAL--
    public float speed = 6.0f;
    public float rotateSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;
    private CharacterController controller;
    private int jumps;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            if(Input.GetKeyDown("space"))
            {
                moveDirection.y = jumpSpeed;
            }
            jumps = 0;
        }
        else
        {
            moveDirection = new Vector3(0, moveDirection.y, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection.x *= speed;
            moveDirection.z *= speed;
            if (Input.GetKeyDown("space") && jumps < 1)
            {
                moveDirection.y = jumpSpeed;
                jumps++;
            }
        }
        transform.Rotate(0, Input.GetAxis("Horizontal"), 0);
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }


    --NO JUMP--
    public float Speed;
    public float SpeedRun;

    private void Update()
    {
        PlayerMovements();
    }

    void PlayerMovements()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 playerMove = new Vector3(horizontal, 0, vertical).normalized * Speed * Time.deltaTime;
        transform.Translate(playerMove, Space.Self);

        if (Input.GetKeyDown("LeftShift"))
        {
            Vector3 playerSpeedMove = new Vector3(horizontal, 0f, vertical) * SpeedRun * Time.deltaTime;
            transform.Translate(playerSpeedMove, Space.Self);
        }
        else
        {
            Vector3 playerMove = new Vector3(horizontal, 0f, vertical) * Speed * Time.deltaTime;
            transform.Translate(playerMove, Space.Self);
        }  
    }*/
