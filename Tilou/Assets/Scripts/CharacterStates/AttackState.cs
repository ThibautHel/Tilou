using UnityEngine;
using UnityEngine.Events;

public class AttackState : State
{
    AnimationClip CurrentClip = null;
    float timePassed;
    float clipLength;
    float clipSpeed;
    bool attack;
    bool AppliedDamages = false;

    public UnityEvent ClipStart = new UnityEvent();
    public UnityEvent ClipEnd = new UnityEvent();

    public AttackState(CharacterScript _player) : base(_player)
    {
    }

    public override void Enter()
    {
        base.Enter();

        attack = true;
        timePassed = 0f;
        Player.Animator.SetBool("isAttacking", true);
        Player.Animator.SetFloat("Speed", 0f);

        ClipStart.AddListener(ResetAttack);
        ClipEnd.AddListener(EndAttack);
    }

    public override void HandleInput()
    {
        base.HandleInput();

        if (Input.GetMouseButtonDown(0))
        {
            attack = true;
            Player.Animator.SetBool("isAttacking", true);
        }
    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        timePassed += Time.deltaTime;
        ResetClip();
    }

    private void ResetClip()
    {
        if (CurrentClip != Player.Animator.GetCurrentAnimatorClipInfo(1)[0].clip)
        {
            ClipStart.Invoke();
            CurrentClip = Player.Animator.GetCurrentAnimatorClipInfo(1)[0].clip;
        }

        if (timePassed >= clipLength / clipSpeed)
        {
            ClipEnd.Invoke();
        }

        clipLength = Player.Animator.GetCurrentAnimatorClipInfo(1)[0].clip.length;
        clipSpeed = Player.Animator.GetCurrentAnimatorStateInfo(1).speed;
    }

    private void ResetAttack()
    {
        if (attack)
        {
            Player.Animator.SetBool("isAttacking", false);
            attack = false;
            timePassed = 0;

        }
    }

    private void EndAttack()
    {
        if (!attack)
        {
            Player.CharachterSM.ChangeState(Player.CombatState);
        }
    }

    public override void Exit()
    {
        base.Exit();

        ClipStart.RemoveListener(ResetAttack);
        ClipEnd.RemoveListener(ResetAttack);
    }
}
