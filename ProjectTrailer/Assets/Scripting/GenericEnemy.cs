using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class GenericEnemy : MonoBehaviour, IGOAP
{

    public float Stamina;
    public float Speed;
    public float AggroDist;
    public float MinDist;
    public float dist;
    public GameObject player;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public HashSet<KeyValuePair<string, object>> getWorldState()
    {
        HashSet<KeyValuePair<string, object>> worldData = new HashSet<KeyValuePair<string, object>>();

        worldData.Add(new KeyValuePair<string, object>("damagePlayer", false));
        worldData.Add(new KeyValuePair<string, object>("evadePlayer", false));

        return worldData;
    }

    public abstract HashSet<KeyValuePair<string, object>> createGoalState();

    public void actionsFinished()
    {
        throw new System.NotImplementedException();
    }


    public void planAborted(GOAPAction aborter)
    {
        throw new System.NotImplementedException();
    }

    public void planFailed(HashSet<KeyValuePair<string, object>> failedGoal)
    {
        throw new System.NotImplementedException();
    }

    public void planFound(HashSet<KeyValuePair<string, object>> goal, Queue<GOAPAction> actions)
    {
        //throw new System.NotImplementedException();
    }

    public bool moveAgent(GOAPAction nextAction)
    {
        dist = Vector3.Distance(transform.position, nextAction.target.transform.position);
        if (dist < AggroDist)
        {
            Vector3 moveDirection = new Vector3 (player.transform.position.x - transform.position.x, 0,0);
            Vector3 newPosition = Vector3.zero;
            
            if (dist <= MinDist)
            {
                nextAction.setInRange(true);
                transform.position += newPosition;
                return true;
            }
            else
            {
                newPosition = moveDirection * Speed * Time.deltaTime;
                transform.position += newPosition;
                return false;
            }
        }
        return false;
    }
}
