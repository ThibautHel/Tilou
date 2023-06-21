using UnityEngine;

[RequireComponent(typeof(PlayerInputs))]
public class Movements : MonoBehaviour
{
    [SerializeField] private float Speed = 5f;
    [SerializeField] private float RotSpeed = 15f;
    [SerializeField] private PlayerInputs PlayerInputs;
    public CharacterController Controller;
    private float TurnVelo;
    private float TurnSmoothTime = .1f;
    public Transform MainCam;
    public Transform AimCam;
    public Transform ThirdPersonCam;

    private void Start()
    {
        MainCam = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        PlayerInputs.OnAimChanged.AddListener(SetCamera);
    }

    private void Move()
    {
        if (!PlayerInputs.isAiming)
        {
            MoveWithoutAim();
        }
        else
        {
            MoveWithAim();
        }
    }
    private void MoveWithAim()
    {
        Vector3 cameraFwd = Camera.main.transform.forward;
        Vector3 flatten_camera = new Vector3(cameraFwd.x, 0, cameraFwd.z).normalized;


        //float target_angle = Mathf.Atan2(flatten_camera.x, flatten_camera.z) * Mathf.Rad2Deg;
        //float angle = Mathf.SmoothDampAngletten_camera.x, flatten_camera.z) * Mathf.Rad2Deg;

        float target_angle = Mathf.Atan2(flatten_camera.x, flatten_camera.z) * Mathf.Rad2Deg;
        float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, target_angle, ref TurnVelo, TurnSmoothTime);

        //transform.rotation = Quaternion.LookRotation(flatten_camera, transform.up);
        transform.rotation = Quaternion.AngleAxis(angle, transform.up);

        Vector3 move_dir = PlayerInputs.MoveDir;
        transform.Translate(move_dir * Time.deltaTime * Speed);
    }

    private void MoveWithoutAim()
    {
        if (PlayerInputs.MoveDir.magnitude > 0)
        {
            float targetAngle = Mathf.Atan2(PlayerInputs.MoveDir.x, PlayerInputs.MoveDir.z) * Mathf.Rad2Deg + MainCam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref TurnVelo, TurnSmoothTime);
            transform.rotation = Quaternion.AngleAxis(angle, transform.up);
            Debug.Log(angle);
            Vector3 moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            transform.Translate(moveDir.normalized * Time.deltaTime * Speed, Space.World);
        }
    }

    private void SetCamera()
    {
        if (PlayerInputs.isAiming)
        {
            /* Vector3 camera_dir = Camera.main.transform.forward;
             Vector3 camera_dir_local = transform.InverseTransformVector(camera_dir);
             */


            ThirdPersonCam.gameObject.SetActive(false);
            AimCam.gameObject.SetActive(true);
        }
        else if (!PlayerInputs.isAiming)
        {
            AimCam.gameObject.SetActive(false);
            ThirdPersonCam.gameObject.SetActive(true);
        }
    }

    public float Atan;
    public float Dot;
    public float angleRad;
    public Vector3 angle_dir;
    private void OnDrawGizmos()
    {
        Vector3 cameraFwd = Camera.main.transform.forward;
        Vector3 flatten_camera_dir = new Vector3(cameraFwd.x, 0, cameraFwd.z);

        //angleRad = Vector3.Angle(transform.forward, flatten_camera_dir) * Mathf.Deg2Rad;
        Dot = Vector3.Dot(transform.forward, flatten_camera_dir.normalized);
        angleRad = Mathf.Acos(Dot);
        angle_dir = new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad)).normalized;

        Gizmos.DrawRay(transform.position, flatten_camera_dir * 100);
        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, angle_dir * 100);

        Gizmos.color = Color.blue;
        Gizmos.DrawLine(transform.position, transform.TransformPoint( Vector3.forward * 5));
        //Gizmos.DrawSphere(transform.TransformPoint(Vector3.forward * 5), 1f);
    }

    void Update()
    {
        //transform.Rotate(Vector3.up,playerInputs.RotationDir * RotSpeed * Time.deltaTime);
        Move();
    }

    private void OnDestroy()
    {
        PlayerInputs.OnAimChanged.RemoveListener(SetCamera);
    }
}
