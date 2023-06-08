using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(PlayerInputs))]
public class Movements : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float RotSpeed = 15f;
    [SerializeField] private PlayerInputs playerInputs;
    public CharacterController controller;
    private float turnVelo;
    private float turnSmoothTime = .1f;

    public Transform cam;

    private void Start()
    {
        cam = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {

        //transform.Rotate(Vector3.up,playerInputs.RotationDir * RotSpeed * Time.deltaTime);
        if (playerInputs.MoveDir.magnitude > 0)
        {
            float targetAngle = Mathf.Atan2(playerInputs.MoveDir.x, playerInputs.MoveDir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnVelo, turnSmoothTime);
            transform.rotation = Quaternion.AngleAxis(angle, transform.up);

            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            transform.Translate( moveDir.normalized * Time.deltaTime * Speed, Space.World);
            Debug.Log(moveDir);
        }
    }
}
