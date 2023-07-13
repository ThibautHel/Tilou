using UnityEngine;

public class ShootV2Test : MonoBehaviour
{

    public float height = 1.0f;
    public float gravity = -5.0f;
    public GameObject bullet;
    public GameObject ball;
    public LayerMask ignoremask;

    public Transform target;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo, 500f, ignoremask))
        {
            //GameObject currentBall = Instantiate(ball,transform.position,Quaternion.identity);
            //Rigidbody rb = currentBall.GetComponent<Rigidbody>();
            /*Physics.gravity = Vector3.up * gravity;
            rb.velocity = CalCulateLaunchVelocity(target.position);
            rb.useGravity= true;
            */

            Vector3 calculatedVelo = CalCulateLaunchVelocity(hitInfo.point);
            Bullet currentBullet = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Bullet>();
           // currentBullet.Initialize(0, calculatedVelo, Camera.main.transform.forward,v, 0, 0,gravity);
        }
    }

    public Vector3 CalCulateLaunchVelocity(Vector3 target)
    {
        float displacementY = target.y - transform.position.y;
        height = displacementY + 1f;
        Vector3 displacementXZ = new Vector3(target.x - transform.position.x, 0, target.z - transform.position.z);

        Vector3 velocityY = Vector3.up * Mathf.Sqrt(-2 * gravity * height);
        Vector3 velocityXZ = displacementXZ / (Mathf.Sqrt(-2 * height / gravity) + Mathf.Sqrt(2 * (displacementY - height) / gravity));

        return velocityXZ + velocityY;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(transform.position, transform.forward * 100);
    }
}
