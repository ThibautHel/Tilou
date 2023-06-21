using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    // -- VARIABLES

    private float launchspeed;
    private Rigidbody rb;
    private float TimeSinceLaunch;

    Vector3 Pos;
    Vector3 Vel;
    Vector3 acc = Physics.gravity;

    // -- PROPERTIES

    public float LaunchSpeed => launchspeed;
    public float TravelTime { get; private set; }

    // -- UNITY
    private void Start()
    {
        Pos = transform.position;
        Vel = transform.forward * launchspeed;
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        if(rb == null) { return; }
        Debug.Log("TESTESTSET");
        TimeSinceLaunch += Time.deltaTime;
        Vector3 next_point = GetPoint(TimeSinceLaunch);
        Vector3 dirToPoint = (next_point - transform.position).normalized;        
        rb.rotation = Quaternion.LookRotation(dirToPoint,Vector3.up);
        rb.position = next_point;
    }

    // -- METHODS 

    public void Initialize(float speed, float gravity = -9.81f)
    {
        launchspeed = speed;
        acc = new Vector3(0, gravity, 0);
    }


    private Vector3 GetPoint(float time)
    {
        return Pos + Vel * time + 0.5f * acc * time * time;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Vector3 next_point = GetPoint(TimeSinceLaunch);
        Vector3 dirToPoint = (next_point - transform.position).normalized;
        Gizmos.DrawLine(transform.position,transform.position + dirToPoint *10);
    }
}
