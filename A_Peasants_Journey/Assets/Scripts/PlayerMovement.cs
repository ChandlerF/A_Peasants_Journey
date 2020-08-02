using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public float walkSpeed = 6f;
    public float sprintSpeed = 10f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;

    Vector3 velocity;
    bool isGrounded;

    public Rigidbody PlayersRigidbody;
    private bool InventoryOpen;
    public GameObject CanvasScript;

    void Start()
    {
        walkSpeed = 8f;
        sprintSpeed = 12f;
       PlayersRigidbody = GetComponent<Rigidbody>();
       InventoryOpen = CanvasScript.GetComponent<InventoryDisplay>().InventoryOpen = false;
    }

   
    void Update()
    {
        if (InventoryOpen == true)
        {
           PlayersRigidbody.constraints = RigidbodyConstraints.FreezeAll;
            Debug.Log("freeze");
        }


        if (Input.GetKey(KeyCode.LeftShift))

        {
            walkSpeed = sprintSpeed;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            walkSpeed = 8f;                     //BE CAREFUL this line of code isn't inspector friendly
        }


        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * walkSpeed * Time.deltaTime);


        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

}
