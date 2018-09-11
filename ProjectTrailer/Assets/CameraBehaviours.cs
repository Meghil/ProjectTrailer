using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviours : MonoBehaviour
{
    public GameObject character;
    private float verticalDistance;

	// Use this for initialization
	void Start ()
    {
        verticalDistance = transform.position.y - character.transform.position.y;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 move = new Vector3(character.transform.position.x, character.transform.position.y + verticalDistance, transform.position.z);

        transform.position = Vector3.Lerp(transform.position, move, 1);
	}
}
