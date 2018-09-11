using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public string OpponentType = "Player";

    static public Dictionary<string, List<Enemy>> OpponentByType;

    public float speed;

    Vector2 velocity;

    public List<WeigthedDirection> DesiredDirection;

    // Use this for initialization
    void Start()
    {
        if (OpponentByType == null)
        {
            OpponentByType = new Dictionary<string, List<Enemy>>();
        }

        if (OpponentByType.ContainsKey(OpponentType) == false)
        {
            OpponentByType[OpponentType] = new List<Enemy>();
        }

        OpponentByType[OpponentType].Add(this);
    }

    void OnDestroy()
    {
        OpponentByType[OpponentType].Remove(this);
    }
    // Update is called once per frame
    void FixedUpdate()
    {


        DesiredDirection = new List<WeigthedDirection>();
        BroadcastMessage("DoIBehaviour", SendMessageOptions.DontRequireReceiver);

        Vector2 dir = Vector2.zero;
        foreach (WeigthedDirection wd in DesiredDirection)
        {
            dir += wd.direction * wd.weight;
        }

        velocity = Vector2.Lerp(velocity, dir.normalized * speed, Time.deltaTime * 5f);

        // Move in the desired direction at our top speed.
        // NOTE: WeightedDirection does include a currently unused parameter for speed
        transform.Translate(velocity * Time.deltaTime);
    }

}
