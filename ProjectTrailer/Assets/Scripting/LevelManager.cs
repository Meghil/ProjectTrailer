using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public float speed;

    public List<string> Position;
    public List<Button> Buttons;
    public List<float> WaitingTime;

    public GameObject LeftSpawnObject;
    public GameObject RightSpawnObject;
    public Canvas canvas; //da sostituire con il pannel che conterrà i tasti

    private Vector3 LeftSpawnPosition;
    private Vector3 RightSpawnPosition;

    private float timer;
    private int listsCount;

    GameObject newGo;
    public GameObject FinalPosition;
    public GameObject StartPointLeft;
    public GameObject StartPointRight;

    
    // Use this for initialization
    void Start ()
    {

        LeftSpawnPosition = LeftSpawnObject.GetComponent<RectTransform>().anchoredPosition;
        RightSpawnPosition = RightSpawnObject.GetComponent<RectTransform>().anchoredPosition;

       
    }

    
	// Update is called once per frame
	void Update ()
    {
        
        
        timer += Time.deltaTime;

        if (timer >= WaitingTime[listsCount])
        {
            Spawn(Position[listsCount], Buttons[listsCount]);
            
            
            timer = 0;
            if (listsCount < Position.Count)
            {
                listsCount += 1;
            }
        }

        if(Input.GetKeyDown(KeyCode.L))
        {
            this.GetComponent<AudioSource>().Play();
        }
        
	}

    void Spawn(string side, Button button)
    {
        newGo = new GameObject();
        Image NewImg = newGo.AddComponent<Image>();
        NewImg.sprite = button.Image;//Square.Image;
        GameObject spawnObject = null;
        Vector3 spawnPosition = Vector3.zero;
        
        if (side == "Left")
        {
            spawnPosition = LeftSpawnPosition;
            spawnObject = LeftSpawnObject;
        }
        else if(side == "Right")
        {
            spawnPosition = RightSpawnPosition;
            spawnObject = RightSpawnObject;
        }

        newGo.GetComponent<RectTransform>().SetParent(canvas.transform);
        newGo.GetComponent<RectTransform>().anchoredPosition = spawnPosition;
        newGo.GetComponent<RectTransform>().anchorMax = spawnObject.GetComponent<RectTransform>().anchorMax;
        newGo.GetComponent<RectTransform>().anchorMin = spawnObject.GetComponent<RectTransform>().anchorMin;
        newGo.AddComponent<ButtonMovement>();
        newGo.AddComponent<BoxCollider>();
        
        newGo.GetComponent<BoxCollider>().size = new Vector3(newGo.GetComponent<RectTransform>().sizeDelta.x, newGo.GetComponent<RectTransform>().sizeDelta.y, 2);
        newGo.GetComponent<BoxCollider>().isTrigger = true;
        newGo.GetComponent<ButtonMovement>().FinalPosition = FinalPosition.transform.position;
        newGo.GetComponent<ButtonMovement>().velocity = Buttons[listsCount].Velocity;
        newGo.GetComponent<ButtonMovement>().DestroyButton = Buttons[listsCount].buttonToPress;
        newGo.SetActive(true);

       
    }

   
}
