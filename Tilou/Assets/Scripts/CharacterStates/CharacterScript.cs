using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharachterInputs))]
public class CharacterScript : MonoBehaviour
{
    public Animator Animator;
    public CharachterInputs Inputs;
    public StateMachine CharachterSM;
    public State StandingState;
    public State CombatState;
    public State AttackState;

    public float Speed = 5f;

    void Start()
    {
        Inputs = gameObject.GetComponent<CharachterInputs>();
        CharachterSM = new StateMachine();
        StandingState = new StandingState(this,CharachterSM);
        CombatState = new CombatState(this,CharachterSM);
        AttackState = new AttackState(this,CharachterSM);

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

    public void EndAttack()
    {
        CharachterSM.ChangeState(CombatState);
        Debug.Log("CALLED");
    }
}
