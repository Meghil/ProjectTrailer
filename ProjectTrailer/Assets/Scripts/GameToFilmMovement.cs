using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameToFilmMovement : MonoBehaviour
{

    public float speed;

    private Vector3 velocity;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        velocity = Vector3.zero;

        velocity += Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime;
        velocity += Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime;

        transform.position += velocity * speed;
    }
}
