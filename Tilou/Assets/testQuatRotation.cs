using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testQuatRotation : MonoBehaviour
{
    public float speed;
    public GameObject pipe;
    public float r, angle;
    Vector3 startpos;
    private void Start()
    {
        r = Mathf.Abs(transform.position.y - pipe.transform.position.y);
        angle = 0;
        transform.position = pipe.transform.position;
        startpos = transform.position;
    }
    void Update()
    {
        angle = angle + speed * Time.deltaTime;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        //transform.position = pipe.transform.position + (transform.rotation * new Vector3(0, r, 0));
        transform.position = pipe.transform.position + transform.up * r;
    }

}
