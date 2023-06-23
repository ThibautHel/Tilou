using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimMovements : MovementsBase
{
    public override void EnterState(Movements playerMovements)
    {
        playerMovements.ThirdPersonCam.gameObject.SetActive(false);
        playerMovements.AimCam.gameObject.SetActive(true);
    }

    public override void UpdateMovements(Movements playerMovements)
    {
        Vector3 cameraFwd = Camera.main.transform.forward;
        Vector3 flatten_camera = new Vector3(cameraFwd.x, 0, cameraFwd.z).normalized;


        //float target_angle = Mathf.Atan2(flatten_camera.x, flatten_camera.z) * Mathf.Rad2Deg;
        //float angle = Mathf.SmoothDampAngletten_camera.x, flatten_camera.z) * Mathf.Rad2Deg;

        float target_angle = Mathf.Atan2(flatten_camera.x, flatten_camera.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(playerMovements.transform.eulerAngles.y, target_angle, ref playerMovements.TurnVelo, playerMovements.TurnSmoothTime);

        //transform.rotation = Quaternion.LookRotation(flatten_camera, transform.up);
        playerMovements.transform.rotation = Quaternion.AngleAxis(angle, playerMovements.transform.up);

        Vector3 move_dir = playerMovements.PlayerInputs.MoveDir;
        playerMovements.transform.Translate(move_dir * Time.deltaTime * playerMovements.Speed);

        if (Input.GetMouseButtonUp(1))
        {
            playerMovements.SetState(playerMovements.NoAimMovements);
        }
    }
}
