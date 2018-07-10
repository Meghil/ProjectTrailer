using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class StartFilm : MonoBehaviour
{
    public Text buttonUI;

    private VideoPlayer wallVideo;


    // Use this for initialization
    void Start()
    {
        wallVideo = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.F))
        {
            Debug.Log("F - Pressed!");
            buttonUI.text = "F";
        }
        if (Input.GetKey(KeyCode.G))
        {
            Debug.Log("G - Pressed!");
            buttonUI.text = "G";
        }
        if (Input.GetKey(KeyCode.H))
        {
            Debug.Log("H - Pressed!");
            buttonUI.text = "H";
        }
        if (Input.GetKey(KeyCode.J))
        {
            Debug.Log("J - Pressed!");
            buttonUI.text = "J";
        }
    }

    void OnTriggerEnter(Collider other)
    {
        wallVideo.Play();
    }
}
