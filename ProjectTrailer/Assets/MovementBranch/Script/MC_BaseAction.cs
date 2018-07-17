using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MC_BaseAction : MonoBehaviour
{
    public BoxCollider2D Sword;

	// Use this for initialization
	void Start ()
    {
        Sword.enabled = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetMouseButton(0) || Input.GetButton("LightAttack"))
        {
            Debug.Log(gameObject.name + "attacco leggero");
            Sword.enabled = true;
        }
        if (Input.GetMouseButton(1) || Input.GetButton("HeavyAttack"))
        {
            Debug.Log(gameObject.name + "attacco pesante");
            Sword.enabled = true;
        }
    }

    
}
