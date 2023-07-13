using UnityEngine;

[RequireComponent(typeof(PlayerInputs))]
public class Movements : MonoBehaviour
{
    [SerializeField] public float Speed = 5f;
    [SerializeField] public float RotSpeed = 15f;
    [SerializeField] public PlayerInputs PlayerInputs;
    public CharacterController Controller;
    public float TurnVelo;
    public float TurnSmoothTime = .1f;
    public Transform MainCam;
    public Transform AimCam;
    public Transform ThirdPersonCam;

    private MovementsBase currentMovementState;

    public AimMovements AimMovements;
    public NoAimMovements NoAimMovements;

    private void Start()
    {
        MainCam = Camera.main.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        //PlayerInputs.OnAimChanged.AddListener(SetState);

        AimMovements = new AimMovements();
        NoAimMovements = new NoAimMovements();

        SetState(NoAimMovements);
    }

    public void SetState(MovementsBase state)
    {
        currentMovementState = state;
        currentMovementState.EnterState(this);

        Debug.Log("switched");
    }

    void Update()
    {
        currentMovementState.UpdateMovements(this);
    }

    private void OnDestroy()
    {
        //PlayerInputs.OnAimChanged.RemoveListener(SetState);
    }

    //Drawing
    //#region
    //public float Atan;
    //public float Dot;
    //public float angleRad;
    //public Vector3 angle_dir;
    //private void OnDrawGizmos()
    //{
    //    Vector3 cameraFwd = Camera.main.transform.forward;
    //    Vector3 flatten_camera_dir = new Vector3(cameraFwd.x, 0, cameraFwd.z);

    //    //angleRad = Vector3.Angle(transform.forward, flatten_camera_dir) * Mathf.Deg2Rad;
    //    Dot = Vector3.Dot(transform.forward, flatten_camera_dir.normalized);
    //    angleRad = Mathf.Acos(Dot);
    //    angle_dir = new Vector3(Mathf.Cos(angleRad), 0, Mathf.Sin(angleRad)).normalized;

    //    Gizmos.DrawRay(transform.position, flatten_camera_dir * 100);
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawRay(transform.position, angle_dir * 100);

    //    Gizmos.color = Color.blue;
    //    Gizmos.DrawLine(transform.position, transform.TransformPoint( Vector3.forward * 5));
    //    //Gizmos.DrawSphere(transform.TransformPoint(Vector3.forward * 5), 1f);
    //}
    //#endregion
}
