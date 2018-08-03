using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class StartFilm : MonoBehaviour
{
    // ########## PUBLIC ##########

    // Debugging things 
    public Text buttonUI;
    public Text videoTimeUI;
    public Text successBetweenUI;
    public GameObject secondCamera;

    // Progress bar (inverse)
    public Slider progressBar;
    public float progressBarMaxValue;
    public float progessBarSpeed;

    // GameObject to to show on screen and to press - add here...
    public GameObject xUI;
    public GameObject bUI;
    public GameObject yUI;


    // ########## PRIVATE ##########

    // Video component (start/stop/time)
    private VideoPlayer wallVideo;

    // Progress bar current value
    private float progressBarCurrentValue;

    // Seconds of the pressed key
    private float timerHoldDownButton;
    private int counterHoldDownButton;


    // Use this for initialization
    void Start()
    {
        wallVideo = GetComponent<VideoPlayer>();
        progressBarCurrentValue = progressBarMaxValue;
        progressBar.value = CalculateProgress();
        timerHoldDownButton = 0f;
        counterHoldDownButton = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (wallVideo.isPlaying)
        {
            // Debug video time
            videoTimeUI.text = wallVideo.time.ToString();


            // Press button in time - add here...
            PressButtonInTime(1f, 2f, 1.3f, 1.7f, 0.5f, 1f, KeyCode.Y, yUI, Vector3.zero);
            PressButtonInTime(3f, 4f, 3.2f, 3.5f, 0.5f, 1f, KeyCode.X, xUI, Vector3.zero);

            // Hold down button in time - add here...
            HoldDownButtonInTime(5f, 10f, 60f, KeyCode.B, bUI, Vector3.zero);
        }


        // Update progress bar
        progressBar.value = Mathf.Lerp(progressBar.value, CalculateProgress(), Time.deltaTime * progessBarSpeed);
    }


    // Start video
    void OnTriggerEnter(Collider other)
    {
        if (!wallVideo.isPlaying)
        {
            secondCamera.SetActive(true);
            wallVideo.Play();
        }
    }


    // Press button in time (method)
    void PressButtonInTime(float timeStart, float timeEnd, float perfectTimeStart, float perfectTimeEnd, float progressBarValue, float progressBarPerfectValue, KeyCode pressedButton, GameObject buttonObj, Vector3 objPosition)
    {
        if (wallVideo.time > timeStart && wallVideo.time < timeEnd)
        {
            if (objPosition != Vector3.zero)
                buttonObj.transform.position = objPosition;

            buttonObj.SetActive(true);
            if (Input.GetKeyDown(pressedButton))
            {
                buttonUI.text = pressedButton.ToString();
                Debug.Log(string.Format("Pressed {0} between {1} and {2} at {3}", pressedButton, timeStart, timeEnd, wallVideo.time));
                successBetweenUI.text = string.Format("Pressed {0} between {1} and {2} at {3}", pressedButton, timeStart, timeEnd, wallVideo.time);

                if (wallVideo.time > perfectTimeStart && wallVideo.time < perfectTimeEnd)
                    progressBarCurrentValue -= progressBarPerfectValue;
                else
                    progressBarCurrentValue -= progressBarValue;
            }
        }
        else
        {
            buttonObj.SetActive(false);
        }
    }

    // Hold down button in time (method)
    void HoldDownButtonInTime(float timeStart, float timeEnd, float waitTime, KeyCode pressedButton, GameObject buttonObj, Vector3 objPosition)
    {
        if (wallVideo.time > timeStart && wallVideo.time < timeEnd)
        {
            if (objPosition != Vector3.zero)
                buttonObj.transform.position = objPosition;

            buttonObj.SetActive(true);
            if (Input.GetKey(pressedButton))
            {
                timerHoldDownButton += Time.deltaTime;
                counterHoldDownButton = (int)(timerHoldDownButton % waitTime);
                buttonUI.text = pressedButton.ToString();
                Debug.Log(string.Format("Hold down {0} between {1} and {2} - {3}", pressedButton, timeStart, timeEnd, counterHoldDownButton));
                successBetweenUI.text = string.Format("Hold down {0} between {1} and {2} - {3}", pressedButton, timeStart, timeEnd, counterHoldDownButton);
                progressBarCurrentValue -= counterHoldDownButton;
            }
        }
        else
        {
            buttonObj.SetActive(false);
            timerHoldDownButton = 0f;
            counterHoldDownButton = 0;
        }
    }


    // Calculate progress bar
    float CalculateProgress()
    {
        return progressBarCurrentValue / progressBarMaxValue;
    }
}
