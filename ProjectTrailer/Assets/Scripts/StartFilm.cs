﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class StartFilm : MonoBehaviour
{
    public Text buttonUI;
    public Text videoTimeUI;
    public Text successBetweenUI;
    public GameObject secondCamera;
    public GameObject pressXUI;
    public GameObject pressBUI;
    public GameObject pressYUI;
    public Slider progressBar;
    public float progressBarMaxValue;
    public float progessBarSpeed;

    private VideoPlayer wallVideo;
    private float progressBarCurrentValue;


    // Use this for initialization
    void Start()
    {
        wallVideo = GetComponent<VideoPlayer>();
        progressBarCurrentValue = progressBarMaxValue;
        progressBar.value = CalculateProgress();
    }

    // Update is called once per frame
    void Update()
    {
        if (wallVideo.isPlaying)
        {
            videoTimeUI.text = wallVideo.time.ToString();

            PressButtonInTime(1f, 2f, KeyCode.Y, pressYUI);
            PressButtonInTime(3f, 4f, KeyCode.X, pressXUI);
            PressButtonInTime(5f, 6f, KeyCode.B, pressBUI);
        }

        progressBar.value = Mathf.Lerp(progressBar.value, CalculateProgress(), Time.deltaTime * progessBarSpeed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!wallVideo.isPlaying)
        {
            secondCamera.SetActive(true);
            wallVideo.Play();
        }
    }

    void PressButtonInTime(float timeA, float timeB, KeyCode pressedButton, GameObject buttonImage)
    {
        if (wallVideo.time > timeA && wallVideo.time < timeB)
        {
            buttonImage.SetActive(true);
            if (Input.GetKeyDown(pressedButton))
            {
                buttonUI.text = pressedButton.ToString();
                Debug.Log(string.Format("Pressed {0} between {1} and {2}", pressedButton, timeA, timeB));
                successBetweenUI.text = string.Format("Pressed {0} between {1} and {2}", pressedButton, timeA, timeB);
                progressBarCurrentValue -= 1;
            }
        }
        else
        {
            buttonImage.SetActive(false);
        }
    }

    float CalculateProgress()
    {
        return progressBarCurrentValue / progressBarMaxValue;
    }
}
