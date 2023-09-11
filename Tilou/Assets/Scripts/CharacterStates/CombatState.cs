using UnityEngine;

public class CombatState : State
{
    public CombatState(CharacterScript _player) : base(_player)
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
        Player.Animator.SetFloat("Speed", Player.Inputs.MoveDir.magnitude, 0.1f, Time.deltaTime);
        if (Input.GetMouseButtonDown(0))
        {
            Player.CharachterSM.ChangeState(Player.AttackState);
        }
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void PhysicsUpdate()
    {
        if (Player.Inputs.MoveDir.magnitude > 0)
        {
            float targetAngle = Mathf.Atan2(Player.Inputs.MoveDir.x, Player.Inputs.MoveDir.y) * Mathf.Rad2Deg + Player.MainCam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(Player.transform.eulerAngles.y, targetAngle, ref Player.TurnVelo, Player.TurnSmoothTime);
            Player.transform.rotation = Quaternion.AngleAxis(angle, Player.transform.up);
            Debug.Log(angle);
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            Player.transform.Translate(moveDir.normalized * Time.deltaTime * Player.PlayerSpeed, Space.World);
        }
    }
}
