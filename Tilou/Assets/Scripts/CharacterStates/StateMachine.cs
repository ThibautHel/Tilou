using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public State CurrentState;
    
    public void Initialize(State state)
    {
        CurrentState = state;
        state.Enter();
    }

    public void ChangeState(State state)
    {
        CurrentState.Exit();

        CurrentState = state;
        state.Enter();
    }

}
