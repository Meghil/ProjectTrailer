using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PirateAttackAction : GOAPAction
{
    private bool AttackDone = false;
    

    public PirateAttackAction()
    {
        addEffect("damagePlayer", true);

    }

    public override void reset()
    {
        AttackDone = false;
        target = null;
    }

    public override bool isDone()
    {
        return AttackDone;
    }

    public override bool requiresInRange()
    {
        return true;
    }

    public override bool checkProceduralPrecondition(GameObject agent)
    {
        target = GameObject.FindGameObjectWithTag("Player");
        if (target != null)
            return true;
        else
            return false;
    }

    public override bool perform(GameObject agent)
    {
        Pirate currentEnemy = agent.GetComponent<Pirate>();

        if (GetComponent<Pirate>().dist <= GetComponent<Pirate>().MinDist )
        {
            //explain conditions

            Debug.Log("attacco");

            AttackDone = true;

            return true;
        }
        else
        {
            Debug.Log("non attacco");

            AttackDone = false;
            reset();

            return false;
        }

    }
    
}
