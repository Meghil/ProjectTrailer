using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pirate : GenericEnemy
{
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public override HashSet<KeyValuePair<string, object>> createGoalState()
    {
        HashSet<KeyValuePair<string, object>> goal = new HashSet<KeyValuePair<string, object>>();
        goal.Add(new KeyValuePair<string, object>("damagePlayer", true));
        goal.Add(new KeyValuePair<string, object>("stayAlive", true));
        return goal;
    }
    
}
