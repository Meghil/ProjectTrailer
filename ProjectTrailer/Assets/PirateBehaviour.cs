using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateBehaviour : MonoBehaviour {

    public string enemytype = "Player";
	// Use this for initialization
	void Start () {
		
	}
	
    void DoIBehaviour()
    {
        if(Enemy.OpponentByType.ContainsKey(enemytype) == false)
        {
            Debug.Log("ciao");
            return;
        }

        Enemy closest = null;
        float dist = Mathf.Infinity;

        foreach (Enemy c in Enemy.OpponentByType[enemytype])
        {
            float d = Vector2.Distance(this.transform.position, c.transform.position);


            //to find the nearest enemy to us
            if(closest == null || d < dist)
            {
                closest = c;
                dist = d;
            }

            if(closest == null)
            {
                Debug.Log("no enemy");
                return;
            }

            Vector2 dir = this.transform.position - closest.transform.position;

            WeigthedDirection wd = new WeigthedDirection(dir, 1);

            this.GetComponent<Enemy>().DesiredDirection.Add(wd);
        }
        
    }
}
