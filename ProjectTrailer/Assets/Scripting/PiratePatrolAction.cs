using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiratePatrolAction : GOAPAction
{
    private bool IsPatroling = false;
    private Vector2 currentPosition;
    private Vector2 startPosition;
    public float PatrolDistance;
    public float Velocity;
    private bool IsForwardPatrolDirection;
    float dist;

    private void Start()
    {
        startPosition = transform.position;
    }
    public PiratePatrolAction()
    {
        addEffect("stayAlive", true);

    }

    public override void reset()
    {
        IsPatroling = false;
        target = null;
    }

    public override bool isDone()
    {
        return IsPatroling;
    }

    public override bool requiresInRange()
    {
        return false;
    }

    public override bool checkProceduralPrecondition(GameObject agent)
    {
        target = GameObject.FindGameObjectWithTag("Player");
        dist = (this.transform.position - target.transform.position).magnitude;
        if (dist > this.gameObject.GetComponent<Pirate>().AggroDist)
            setInRange(false);
        if (!isInRange())
            return true;
        else
            return false;
    }

    public override bool perform(GameObject agent)
    {
        Pirate currentEnemy = agent.GetComponent<Pirate>();
        currentPosition = transform.position;
        if (currentEnemy.Stamina >= cost && !isInRange())
        {
            //explain conditions
            if (IsForwardPatrolDirection)
            {
                transform.position += transform.right * Velocity * Time.deltaTime;
                if (currentPosition.x <= startPosition.x - PatrolDistance)
                {
                    IsForwardPatrolDirection = false;
                }
            }
            else
            {
                transform.position -= transform.right * Velocity * Time.deltaTime;
                if (currentPosition.x >= startPosition.x + PatrolDistance)
                {
                    IsForwardPatrolDirection = true;
                }
            }

            Debug.Log("patrollo");

            IsPatroling = true;
            

            return true;
        }
        else
        {
            Debug.Log("non patrollo");

            IsPatroling = false;

            return false;
        }

    }
}
