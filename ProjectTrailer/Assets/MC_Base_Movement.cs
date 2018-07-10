using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_Base_Movement : MonoBehaviour
{
    public Vector3 Velocity;
    public float JumpPower;
    private Rigidbody2D body;
    private bool isGrounded;

	// Use this for initialization
	void Start ()
    {
        body = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += Velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= Velocity * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            body.AddForce(Vector2.up * JumpPower);
            isGrounded = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Terrain")
        {
            isGrounded = true;
            Debug.Log(isGrounded);
        }
        else
        {
            isGrounded = false;
            Debug.Log(isGrounded);
        }
    }

}
