using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    public Button Square;
    public Button X;
    public Button Triangle;
    public Button Circle;

    public GameObject LeftSpawnObject;
    public GameObject RightSpawnObject;
    public Canvas canvas; //da sostituire con il pannel che conterrà i tasti

    private Vector3 LeftSpawnPosition;
    private Vector3 RightSpawnPosition;
	// Use this for initialization
	void Start ()
    {
        LeftSpawnPosition = LeftSpawnObject.GetComponent<RectTransform>().anchoredPosition;
        RightSpawnPosition = RightSpawnObject.GetComponent<RectTransform>().anchoredPosition;
        GameObject newGo = new GameObject();
        Image NewImg = newGo.AddComponent<Image>();
        NewImg.sprite = Square.Image;
        newGo.GetComponent<RectTransform>().SetParent(canvas.transform);
        newGo.GetComponent<RectTransform>().anchoredPosition = LeftSpawnPosition;
        newGo.GetComponent<RectTransform>().anchorMax = LeftSpawnObject.GetComponent<RectTransform>().anchorMax;
        newGo.GetComponent<RectTransform>().anchorMin = LeftSpawnObject.GetComponent<RectTransform>().anchorMin;
        newGo.SetActive(true);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
