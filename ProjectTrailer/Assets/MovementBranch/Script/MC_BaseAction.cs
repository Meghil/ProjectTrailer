using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_BaseAction : MonoBehaviour
{
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetMouseButton(0) || Input.GetButton("LightAttack"))
        {
            Debug.Log(gameObject.name + "attacco leggero");
        }
        if (Input.GetMouseButton(1) || Input.GetButton("HeavyAttack"))
        {
            Debug.Log(gameObject.name + "attacco pesante");
        }
    }
}
