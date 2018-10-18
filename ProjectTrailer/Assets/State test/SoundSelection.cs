using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundSelection : MonoBehaviour
{

    //scrip to create new state maschine on the owner
    public StateMachine nStateMachine = new StateMachine();

    private void Start()
    {
        nStateMachine.ChangeState(new StateforTest(1 /*example int*/, this.gameObject));
    }

    private void Update()
    {
        nStateMachine.ExecuteUpdate();
    }



}
