using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private Animator animator;

    private float verticalVelocity;
    public float horizontalVelocity;
    public float JumpForce;
    public float gravity;

	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        float horizontal = Input.GetAxis("Horizontal");
        animator.SetFloat("Move", horizontal);
        animator.SetBool("IsJumping", controller.isGrounded);
	    if(controller.isGrounded)
        {
            verticalVelocity -= gravity * Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = JumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
        Vector3 moveVector = new Vector3(horizontal * horizontalVelocity * Time.deltaTime, verticalVelocity, 0);

        controller.Move(moveVector * Time.deltaTime);
	}
}
