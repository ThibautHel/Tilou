using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterScript : MonoBehaviour
{
    private StateMachine CharachterSM;
    private State StandingState;

    public float Speed = 5f;

    void Start()
    {
        CharachterSM = new StateMachine();
        StandingState = new StandingState(this,CharachterSM);
    }

    void Update()
    {
        
    }
}
