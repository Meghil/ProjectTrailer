using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLeftQueue : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /*private void OnTriggerEnter(Collider other)
    {
    if (NoteOrder.Peek().GetComponent<ButtonMovement>().Durability > 0)
            {
                timer += Time.deltaTime;
                if (timer >= NoteOrder.Peek().GetComponent<ButtonMovement>().Durability)
                {
                    Destroy(NoteOrder.Dequeue());
                    points += 100;
                    Points.text = points.ToString();
                }
            }
        Debug.Log(other);
        if (other.gameObject.GetComponent<ButtonMovement>())
        {
            this.GetComponentInParent<BottonsAreasDetection>().LNoteOrder.Enqueue(other.gameObject);
        }
    }*/
}
