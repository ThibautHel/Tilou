using UnityEngine;

public class RangedState : State
{
    private bool isShooting = false;
    public RangedState(CharacterScript _player) : base(_player)
    {
    }

    public override void Enter()
    {
        base.Enter();

        Player.Animator.SetTrigger("SwapWeapon");
    }
    public override void Exit()
    {
        base.Exit();
    }
    public override void HandleInput()
    {
        base.HandleInput();
        isShooting = Input.GetMouseButton(0);

    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        Player.Animator.SetBool("isMoving", isMoving);
        Player.Animator.SetBool("isShooting", isShooting);

        if (Input.GetMouseButton(1))
        {
            Player.CharachterSM.ChangeState(Player.AimingState);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        Vector3 movement = new Vector3(Player.Inputs.MoveDir.x, 0, Player.Inputs.MoveDir.y) * Player.PlayerSpeed * Time.deltaTime;
        Player.gameObject.transform.Translate(movement);

        if (isShooting)
        {
            Player.ShootScript.ShootInput();
        }
    }

}
