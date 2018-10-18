using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateforTest : IStates
{
    private int subjectOfState; //eventual element usefull to complete the state
    private GameObject gameObjectOwner; //who use this state

    public StateforTest(int subject, GameObject owner)
    {
        subjectOfState = subject;
        gameObjectOwner = owner;
    }

    public void Enter()
    {
        
    }

    public void Execute()
    {
       //check subject status and create the event and the actions
    }

    public void Exit()
    {
       
    }
}
