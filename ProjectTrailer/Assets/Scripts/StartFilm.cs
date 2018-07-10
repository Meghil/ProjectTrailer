using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartFilm : MonoBehaviour
{

    //private BoxCollider wallCollider;


    // Use this for initialization
    void Start()
    {
        //wallCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Video triggered D:");
    }
}
