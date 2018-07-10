using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Base_Movement : MonoBehaviour
{
    public float Velocity;
    public float JumpPower;
    private Rigidbody2D body;
    private bool isGrounded;
    private Vector3 movement;

	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        float xMove = Input.GetAxis("Horizontal");
        
        movement = new Vector3(xMove, 0, 0);

        transform.position += movement * Velocity * Time.deltaTime;
       
        if ((Input.GetKey(KeyCode.Space) || Input.GetButton("Jump")) && isGrounded)
        {
            body.AddForce(Vector2.up * JumpPower);
            isGrounded = false;
        }
        Debug.Log(isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            isGrounded = true;
        }
    }

}
