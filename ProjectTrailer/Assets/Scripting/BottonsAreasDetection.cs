using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottonsAreasDetection : MonoBehaviour
{
    public Text Points;
    private float points;
    public Queue<GameObject> NoteOrder;

    // Use this for initialization
    void Start ()
    {
        NoteOrder = new Queue<GameObject>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        Debug.Log(NoteOrder.Peek().GetComponent<ButtonMovement>().DestroyButton);
        if (Input.GetButtonDown(NoteOrder.Peek().GetComponent<ButtonMovement>().DestroyButton))
        {
            Destroy(NoteOrder.Dequeue());
            points += 100;
            Points.text = points.ToString();
        }
        if (NoteOrder.Peek().GetComponent<ButtonMovement>().FinalPosition == NoteOrder.Peek().transform.position)
        {
            Destroy(NoteOrder.Dequeue());
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other);
        if (other.gameObject.GetComponent<ButtonMovement>())
        {
            NoteOrder.Enqueue(other.gameObject);         
        }
    }
    
}
