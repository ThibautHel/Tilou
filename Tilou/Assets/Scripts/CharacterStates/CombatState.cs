using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombatState : State
{
    public CombatState(CharacterScript _player, StateMachine _stateMahine) : base(_player, _stateMahine)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Player.Animator.SetFloat("speed", Player.Inputs.MoveDir.y, 0.1f, Time.deltaTime);
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void PhysicsUpdate()
    {
        Vector3 movement = new Vector3(Player.Inputs.MoveDir.x, 0, Player.Inputs.MoveDir.y) * Player.Speed * Time.deltaTime;
        Player.gameObject.transform.Translate(movement);
    }
}
