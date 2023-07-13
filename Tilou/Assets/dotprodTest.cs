using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;

public class dotprodTest : MonoBehaviour
{
    public Transform A;
    public Transform B;
    public Transform C;
    public Transform D;

    public Vector3 Cvelocity;
    public Vector3 Dvelocity;
    public Vector3 Cacc;
    public Vector3 Dacc;

    public float tTest;


    private void OnDrawGizmos()
    {
        // -- TEST 1

        //Vector3 AposDelta = A.position - transform.position;
        //Vector3 BposDelta = B.position - transform.position;
        //Vector3 ADir = (A.position - transform.position).normalized;

        //Vector3 ABdelta = A.position - B.position;
        //Gizmos.color = Color.cyan;
        //Gizmos.DrawLine(default, ABdelta);


        //Gizmos.DrawLine(transform.position, A.position);
        //Gizmos.DrawLine(transform.position, B.position);

        //Gizmos.color = Color.green;

        //Gizmos.DrawLine(default, AposDelta);
        //Gizmos.DrawLine(default, BposDelta);

        //float dot = Vector2.Dot(AposDelta.normalized, BposDelta);

        //Gizmos.DrawSphere(transform.position + (ADir * dot), .5f);
        //Gizmos.DrawLine(BposDelta, AposDelta.normalized * dot);

        // -- TEST 2

        Gizmos.DrawLine(A.position, A.position + A.forward * 10);
        Gizmos.DrawRay(B.position, B.forward * 10);

        Vector3 ABdelta = B.position + B.forward * 10 - A.position;

        Gizmos.DrawLine(default,ABdelta);

        float dot = Vector3.Dot(A.forward.normalized, ABdelta);
        Gizmos.DrawSphere(A.position + A.forward * dot, .5f);

        Vector3 testpoint = GetPoint(tTest, C.position, Cvelocity, Cacc);
        Vector3 testpoint2 = GetPoint(tTest, D.position, Dvelocity, Dacc);

        Vector3 relTestpoint = testpoint2 - C.position;
        Vector3 Cdir = testpoint - C.position;

        //Gizmos.DrawSphere(testpoint,.5f);
        Gizmos.DrawLine(C.position, testpoint);
        Gizmos.DrawSphere(testpoint2,.5f);
        Gizmos.DrawLine(D.position, testpoint2);

        float dot2 = Vector3.Dot( Cdir.normalized,relTestpoint);
        Vector3 vectorProj = C.position + Cdir.normalized * dot2;
        Gizmos.DrawSphere( vectorProj, .5f);

        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(new Vector3(vectorProj.x, vectorProj.y , testpoint2.z), .5f);

    }

    private Vector3 GetPoint(float time, Vector3 Pos, Vector3 Vel, Vector3 acc)
    {
        return Pos + Vel * time + 0.5f * acc * time * time;
    }
}
