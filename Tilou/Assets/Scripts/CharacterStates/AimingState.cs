using UnityEngine;

public class AimingState : State
{
    private bool isShooting = false;

    public AimingState(CharacterScript _player) : base(_player)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.ThirdPersonCam.gameObject.SetActive(false);
        Player.AimCam.gameObject.SetActive(true);
    }
    public override void Exit()
    {
        base.Exit();
        Player.ThirdPersonCam.gameObject.SetActive(true);
        Player.AimCam.gameObject.SetActive(false);
    }
    public override void HandleInput()
    {
        base.HandleInput();
        isShooting = Input.GetMouseButton(0);

    }
    public override void LogicUpdate()
    {
        base.LogicUpdate();

        Player.Animator.SetBool("isShooting", isShooting);

        if (Input.GetKeyDown(KeyCode.T) || Input.GetMouseButtonUp(1))
        {
            Player.CharachterSM.ChangeState(Player.RangedState);
        }
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        Vector3 cameraFwd = Camera.main.transform.forward;
        Vector3 flatten_camera = new Vector3(cameraFwd.x, 0, cameraFwd.z).normalized;
        float target_angle = Mathf.Atan2(flatten_camera.x, flatten_camera.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(Player.transform.eulerAngles.y, target_angle, ref Player.TurnVelo, Player.TurnSmoothTime);

        Player.transform.rotation = Quaternion.AngleAxis(angle, Player.transform.up);

        Vector3 move_dir = Player.Inputs.MoveDir;
        Player.transform.Translate(move_dir * Time.deltaTime * Player.PlayerSpeed);

        if (isShooting)
        {
            Player.ShootScript.ShootInput();
        }
    }
}
