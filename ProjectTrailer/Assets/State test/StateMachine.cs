using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IStates currentRunningState;
    private IStates previousState;

    public void ChangeState(IStates newState)
    {
        if (currentRunningState != null)
        {
            currentRunningState.Exit();
        }
        previousState = currentRunningState;
        currentRunningState = newState;
        currentRunningState.Enter();
    }

    public void ExecuteUpdate()
    {
        var CurrentState = currentRunningState;
        if (CurrentState != null)
        {
            CurrentState.Execute();
        }
    }

    public void ReturnToPreviousState()
    {
        currentRunningState.Exit();
        currentRunningState = previousState;
        currentRunningState.Enter();
    }
}
