using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAimMovements : MovementsBase
{
    public override void EnterState(Movements playerMovements)
    {
        playerMovements.AimCam.gameObject.SetActive(false);
        playerMovements.ThirdPersonCam.gameObject.SetActive(true);
    }


    public override void UpdateMovements(Movements playerMovements)
    {
        if (playerMovements.PlayerInputs.MoveDir.magnitude > 0)
        {
            float targetAngle = Mathf.Atan2(playerMovements.PlayerInputs.MoveDir.x, playerMovements.PlayerInputs.MoveDir.z) * Mathf.Rad2Deg + playerMovements.MainCam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(playerMovements.transform.eulerAngles.y, targetAngle, ref playerMovements.TurnVelo, playerMovements.TurnSmoothTime);
            playerMovements.transform.rotation = Quaternion.AngleAxis(angle, playerMovements.transform.up);
            Debug.Log(angle);
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            playerMovements.transform.Translate(moveDir.normalized * Time.deltaTime * playerMovements.Speed, Space.World);
        }

        if (Input.GetMouseButtonDown(1))
        {
            playerMovements.SetState(playerMovements.AimMovements);
        }
    }
}
