using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class StartFilm : MonoBehaviour
{
    public Text buttonUI;
    public Text videoTimeUI;
    public Text successBetweenUI;

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

        if (wallVideo.isPlaying)
        {
            videoTimeUI.text = wallVideo.time.ToString();

            if ((wallVideo.time > 5f && wallVideo.time < 6f) && Input.GetKey(KeyCode.Q))
            {
                Debug.Log("Pressed Q between 5 and 6");
                successBetweenUI.text = "Pressed Q between 5 and 6";
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (!wallVideo.isPlaying)
        {
            wallVideo.Play();
        }
    }
}
