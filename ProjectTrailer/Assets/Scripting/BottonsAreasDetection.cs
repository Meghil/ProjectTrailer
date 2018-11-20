using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BottonsAreasDetection : MonoBehaviour
{
    public Text Points;
    private float points;
    public Queue<GameObject> NoteOrder;
    public Queue<GameObject> LNoteOrder;
    private float timer;

    // Use this for initialization
    void Start ()
    {
        NoteOrder = new Queue<GameObject>();
        LNoteOrder = new Queue<GameObject>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (NoteOrder.Peek().GetComponent<ButtonMovement>().Durability > 0)
        {
            if (Input.GetButton(NoteOrder.Peek().GetComponent<ButtonMovement>().DestroyButton))
            {
                timer += Time.deltaTime;
                if (timer >= NoteOrder.Peek().GetComponent<ButtonMovement>().Durability)
                {
                    Destroy(NoteOrder.Dequeue());
                    points += 10000;
                    Points.text = points.ToString();
                }
            }
        }
        else
        { 
            if (Input.GetButtonDown(NoteOrder.Peek().GetComponent<ButtonMovement>().DestroyButton))
            {
                Destroy(NoteOrder.Dequeue());
                points += 100;
                Points.text = points.ToString();
            }
        }
        if (NoteOrder.Peek().GetComponent<ButtonMovement>().FinalPosition == NoteOrder.Peek().transform.position)
        {
            if (NoteOrder.Peek().GetComponent<ButtonMovement>().Durability <= 0)
            {
                Destroy(NoteOrder.Dequeue());
            }
        }
    }

    private void OnTriggerEnter(Collider other)
   {
       if (other.gameObject.GetComponent<ButtonMovement>())
       {
           this.GetComponentInParent<BottonsAreasDetection>().NoteOrder.Enqueue(other.gameObject);
       }
   }

}
