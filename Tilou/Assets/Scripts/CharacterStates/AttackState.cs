using System.Collections;
using System.Collections.Generic;
using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.TextCore.Text;
using static UnityEditor.Experimental.GraphView.GraphView;

public class AttackState : State
{
    float timePassed;
    float clipLength;
    float clipSpeed;
    bool attack;
    public AttackState(CharacterScript _player, StateMachine _stateMachine) : base(_player, _stateMachine)
    {
    }

    public override void Enter()
    {
        base.Enter();

        attack = false;
        timePassed = 0f;
        Player.Animator.SetTrigger("Attack");
        Player.Animator.SetFloat("Speed", 0f);
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (Input.GetMouseButtonDown(0))
        {
            attack = true;
        }
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        timePassed += Time.deltaTime;
        ResetClip();

        if (timePassed >= clipLength / clipSpeed && attack)
        {
            //StateMachine.ChangeState(Player.AttackState);
            Player.Animator.SetTrigger("Attack");
            attack = false;
            timePassed = 0;
        }
        if (timePassed >= clipLength / clipSpeed && !attack)
        {
            StateMachine.ChangeState(Player.CombatState);
        }

    }

    private void ResetClip()
    {
        clipLength = Player.Animator.GetCurrentAnimatorClipInfo(1)[0].clip.length;
        clipSpeed = Player.Animator.GetCurrentAnimatorStateInfo(1).speed;
    }

    public override void Exit()
    {
        base.Exit();
    }
}
