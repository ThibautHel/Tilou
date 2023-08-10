using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharachterInputs))]
public class CharacterScript : MonoBehaviour
{
    public Animator Animator;
    public CharachterInputs Inputs;
    private StateMachine CharachterSM;
    public State StandingState;
    public State CombatState;

    public float Speed = 5f;

    void Start()
    {
        Inputs = gameObject.GetComponent<CharachterInputs>();
        CharachterSM = new StateMachine();
        StandingState = new StandingState(this,CharachterSM);
        CombatState = new CombatState(this,CharachterSM);

        CharachterSM.Initialize(StandingState);
    }

    void Update()
    {
        CharachterSM.CurrentState.HandleInput();
        CharachterSM.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        CharachterSM.CurrentState.PhysicsUpdate();
    }
}
