using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    // -- VARIABLES

    [Header("Physics")]
    private float launchspeed;
    private Rigidbody rb;
    Vector3 Pos;
    Vector3 Vel;
    Vector3 yVel;
    Vector3 acc;
    public float timeSinceLaunch;

    Vector3 CameraDir = Vector3.zero;
    Vector3 CameraPos = Vector3.zero;
    Vector3 DirToCamera = Vector3.zero;

    [Header("BulletData")]
    [SerializeField] private float MaxLifeTime = 3f;
    private float Damages = 0f;

    public Vector3 next_point;
    bool trajectoryAdjusted = false;

    [SerializeField] Vector3 startpos = Vector3.zero;
    [SerializeField] Vector3 startVelo = Vector3.zero;
    [SerializeField] Vector3 originalAcc = Vector3.zero;
    [SerializeField] float newTimer = 0;

    // -- PROPERTIES

    private float TimeSinceLaunch
    {
        get => timeSinceLaunch;
        set
        {
            timeSinceLaunch = value;
            if (timeSinceLaunch > MaxLifeTime) { Destroy(gameObject); }
        }
    }
    public float LaunchSpeed => launchspeed;
    public float TravelTime { get; private set; }

    // -- UNITY

    private void Start()
    {
        Pos = transform.position;
        rb = GetComponent<Rigidbody>();
        //rb.velocity = Vel;
    }

    void Update()
    {
        if (rb == null) { return; }
        TimeSinceLaunch += Time.deltaTime;

        next_point = GetPoint(TimeSinceLaunch, Pos, Vel, acc);
        //transform.LookAt(transform.position + rb.velocity);
        Vector2 pointForward = new Vector2(transform.position.x - CameraPos.x, transform.position.z - CameraPos.z);
        Vector2 pointToCamera = new Vector2(CameraDir.x, CameraDir.z);


        if (WedgeProduct(pointToCamera, pointForward) < 0 /*&& !trajectoryAdjusted*/)
        {
            // -- FIRST OPTION
            //rb.velocity = CameraDir * LaunchSpeed;
            //trajectoryAdjusted = true;

            // -- SECOND TRY

            if (!trajectoryAdjusted)
            {
                startpos = transform.position;
                Vector3 initialVelo = GetVelocity(timeSinceLaunch);
                startVelo = CameraDir * launchspeed;
                originalAcc = acc;
                newTimer = 0;
                trajectoryAdjusted = true;
            }

            Vector3 Pos2Delta = GetPoint(timeSinceLaunch,Pos,Vel, acc);
            Vector3 relTestpoint =  Pos2Delta - startpos;

            float dot2 = Vector3.Dot(CameraDir.normalized, relTestpoint);
            Vector3 vectorProj = startpos + CameraDir.normalized * dot2;

            next_point = new Vector3(vectorProj.x, Pos2Delta.y, vectorProj.z);



            rb.position = next_point;
            transform.LookAt(next_point - transform.position);
        }
        else
        {
            Vector3 dirToPoint = (next_point - transform.position).normalized;
            rb.position = next_point;
            rb.rotation = Quaternion.LookRotation(dirToPoint, Vector3.up);
        }
    }

    // -- METHODS 

    public void Initialize(float speed, Vector3 dirFromFirepointToRaycastHit, Vector3 _CameraDir, Vector3 cameraPos, float yVelo, float damages, float gravity = -9.81f)
    {
        DirToCamera = dirFromFirepointToRaycastHit;
        CameraDir = _CameraDir;
        CameraPos = cameraPos;

        launchspeed = speed;
        //Vel = velocityDir; // ShootV2
        acc = new Vector3(0, gravity, 0);
        Damages = damages;

        Vel = DirToCamera.normalized * launchspeed + Vector3.up * yVelo; // ShootV1
    }

    public static float WedgeProduct(Vector2 a, Vector2 b)
    {
        return a.x * b.y - a.y * b.x;
    }

    private Vector3 GetPoint(float time, Vector3 Pos, Vector3 Vel, Vector3 acc)
    {
        return Pos + Vel * time + 0.5f * acc * time * time;
    }
    private Vector3 GetVelocity(float time)
    {
        return Vel + acc * time;
    }

    public static Vector3 FlattenYaxis(Vector3 v)
    {
        return new Vector3(v.x, 0, v.z);
    }

    // -- UNITY METHODS

    private void OnCollisionEnter(Collision collision)
    {
        if (collision == null) { return; }

        if (collision.transform.TryGetComponent(out IHealth health))
        {
            health.TakeDmg(Damages);
        }
    }
    private void OnDrawGizmos()
    {
        //Gizmos.color = Color.green;
        //Vector3 next_point = GetPoint(TimeSinceLaunch, Pos, Vel, acc);
        //Vector3 dirToPoint = (next_point - transform.position).normalized;
        //Gizmos.DrawLine(transform.position, transform.position + dirToPoint * 10);

        //Vector2 pointFromCameraToBullet = new Vector2(transform.position.x - CameraPos.x, transform.position.z - CameraPos.z);
        //Vector2 CameraForward = new Vector2(CameraDir.x, CameraDir.z);

        //  Gizmos.color = Color.magenta;
        //  Gizmos.DrawLine(CameraPos, transform.position);

        //Gizmos.color = Color.red;
        //Gizmos.DrawRay(CameraPos, DirToCamera * 100);

        //Gizmos.color = Color.red;
        //Gizmos.DrawRay(CameraPos, CameraForward * 100);

        //Gizmos.color = Color.yellow;
        //Gizmos.DrawRay(CameraPos, CameraDir * 100);

        //  Gizmos.color = Color.gray;
        //  Gizmos.DrawRay(transform.position, CameraDir * 100);


        Vector3 Pos1 = GetPoint(newTimer, startpos, startVelo, acc);
        Vector3 Pos2Delta = GetPoint(timeSinceLaunch, Pos, Vel, acc);

        Vector3 relTestpoint = Pos2Delta - startpos;

        float dot2 = Vector3.Dot(CameraDir.normalized, relTestpoint);
        Vector3 vectorProj = startpos + CameraDir.normalized * dot2;



        Gizmos.DrawLine(startpos, Pos2Delta);
        Gizmos.DrawLine(Pos2Delta, vectorProj);

        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(Camera.main.transform.position, vectorProj);


        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(Pos2Delta,new Vector3(vectorProj.x, Pos2Delta.y, vectorProj.z));

    }
}
