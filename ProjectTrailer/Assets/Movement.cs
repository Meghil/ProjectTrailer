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
    public GameObject feet;
    public GameObject RightHand;
    public GameObject LeftHand;
    RaycastHit hit;

    private bool isAttacking;
    

	// Use this for initialization
	void Start ()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Attack();

        if (animator.GetFloat("NextAttack") < 0.1)
        {
            Debug.DrawRay(feet.transform.position, Vector3.down, Color.red, 0.1f);
            
            float horizontal = Input.GetAxis("Horizontal");
            animator.SetFloat("Move", horizontal);
            if (horizontal > 0)
            {
                transform.forward = Vector3.right;
            }
            else if (horizontal < 0)
            {
                transform.forward = -Vector3.right;
            }

            if (Physics.Raycast(feet.transform.position, Vector3.down, out hit, 0.15f))
            {
                Debug.Log(hit.distance);
                if (hit.collider.tag == "Terrain")
                {
                    verticalVelocity = 0;
                    animator.SetBool("IsJumping", false);
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        verticalVelocity = JumpForce;
                        animator.SetBool("IsJumping", true);
                    }
                }
            }
            else
            {
                animator.SetBool("IsJumping", true);
                verticalVelocity -= gravity * Time.deltaTime;
                

            }
            Vector3 moveVector = new Vector3(horizontal * horizontalVelocity * Time.deltaTime, verticalVelocity, 0);

            controller.Move(moveVector * Time.deltaTime);

        }

        
	}
    
    void Attack()
    {
        if (Input.GetMouseButtonDown(0))
        {
            animator.SetBool("Attack", true);
            
        }
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetBool("HeavyAttack", true);

        }
        if (animator.GetFloat("NextAttack") > 0.6)
        {
            RightHand.GetComponent<CapsuleCollider>().enabled = true;
            LeftHand.GetComponent<CapsuleCollider>().enabled = true;
        }
        else
        {
            RightHand.GetComponent<CapsuleCollider>().enabled = false;
            LeftHand.GetComponent<CapsuleCollider>().enabled = false;
        }

    }

    
}
