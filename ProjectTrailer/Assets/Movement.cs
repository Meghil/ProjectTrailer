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
    public GameObject CheckGrab1;
    public GameObject CheckGrab2;
    public GameObject CheckGrab3;
    RaycastHit hit;

    private bool isAttacking;
    private bool canGrab;

    public bool IkActive;
    public Transform IkRightHand;
    public Transform IkLeftHand;
    

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
                if (canGrab)
                {
                    verticalVelocity = 0;
                }
                else
                {
                    verticalVelocity -= gravity * Time.deltaTime;
                }
                

            }
            Vector3 moveVector = new Vector3(horizontal * horizontalVelocity * Time.deltaTime, verticalVelocity, 0);

            controller.Move(moveVector * Time.deltaTime);

            Grab();
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

    void Grab()
    {
        RaycastHit grab1;
        RaycastHit grab2;
        RaycastHit grab3;

        Debug.DrawRay(CheckGrab1.transform.position, transform.forward, Color.green, 0.5f);
        Debug.DrawRay(CheckGrab2.transform.position, transform.forward, Color.green, 0.5f);
        Debug.DrawRay(CheckGrab3.transform.position, transform.forward, Color.green, 0.5f);

        if (!Physics.Raycast(CheckGrab1.transform.position, transform.forward, out grab1, 0.5f) && Physics.Raycast(CheckGrab2.transform.position, transform.forward, out grab2, 0.5f) && Physics.Raycast(CheckGrab3.transform.position, transform.forward, out grab3, 0.5f)) 
        {

            

            Debug.Log(grab1.collider);
            if (grab1.collider == null && grab2.collider.tag == "Terrain" && grab3.collider.tag == "Terrain")
            {
                canGrab = true;
                IkActive = true;
                IkLeftHand = grab2.collider.transform.Find("LeftHandGrab");
                IkRightHand = grab2.collider.transform.Find("RightHandGrab");
                animator.SetLayerWeight(0, 0);
                animator.SetLayerWeight(1, 1);
            }
        }
        else
        {
            canGrab = false;
            IkActive = false;
            animator.SetLayerWeight(0, 1);
            animator.SetLayerWeight(1, 0);
        }
    }

    private void OnAnimatorIK()
    {
        if(IkActive)
        {
            if(IkLeftHand != null)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
                animator.SetIKPosition(AvatarIKGoal.LeftHand, IkLeftHand.position);
            }
            if(IkRightHand)
            {
                animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
                animator.SetIKPosition(AvatarIKGoal.RightHand, IkRightHand.position);
            }
        }
        else
        {
            animator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 0);
            animator.SetIKPositionWeight(AvatarIKGoal.RightHand, 0);
        }
    }


}
