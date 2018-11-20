using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    Vector3 startPosition;
    public Vector3 FinalPosition;
    public string DestroyButton;
    public float velocity;
    public float Durability;
    Camera usedCamera;
    Ray ray;

    RaycastHit hit;
    
	// Use this for initialization
	void Start ()
    {
        startPosition = transform.position;
        usedCamera = Camera.main;
        ray = usedCamera.ScreenPointToRay(FinalPosition);

    }
    float count = 0.0f;
    // Update is called once per frame
    void Update ()
    {
        if (count < 1.0f)
        {
            count += 1 * Time.deltaTime * velocity;
            Vector3 m1 = Vector3.Lerp(startPosition, new Vector3(startPosition.x, FinalPosition.y, 0), count);
            Vector3 m2 = Vector3.Lerp(new Vector3(startPosition.x, FinalPosition.y, 0), FinalPosition, count);
            transform.position = Vector3.Lerp(m1, m2, count);
        }

        if(Physics.Raycast(ray, out hit))
        {
            Debug.Log(hit.collider.gameObject.name);
        }

        
    }
}
