using UnityEngine;

public class StandingState : State
{
    public StandingState(CharacterScript _player) : base(_player)
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
        Player.Animator.SetFloat("Speed", Player.Inputs.MoveDir.y, 0.1f, Time.deltaTime);
        Debug.Log(Player.Inputs.MoveDir.y);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    Player.Animator.SetTrigger("EquipWeapon");
        //    Player.CharachterSM.ChangeState(Player.CombatState);
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    Player.Animator.SetTrigger("Jump");
        //}

        if (Input.GetKeyDown(KeyCode.T))
        {
            Player.Animator.SetTrigger("SwapWeapon");
            Player.CharachterSM.ChangeState(Player.RangedState);
        }
    }

    public override void HandleInput()
    {
        base.HandleInput();
    }

    public override void PhysicsUpdate()
    {
        Vector3 movement = new Vector3(Player.Inputs.MoveDir.x, 0, Player.Inputs.MoveDir.y) * Player.PlayerSpeed * Time.deltaTime;
        Player.gameObject.transform.Translate(movement);
    }
}
