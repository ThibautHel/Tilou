using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandingState : State
{
    public StandingState(CharacterScript _player, StateMachine _stateMahine) : base(_player, _stateMahine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        MoveInput = Vector2.zero;
    }

    public override void Exit() 
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void HandleInput()
    {
        base.HandleInput();
        MoveInput = new Vector2( Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }

    public override void PhysicsUpdate() 
    {
        Player.gameObject.transform.Translate(MoveInput.normalized * Player.Speed);
    }
}
