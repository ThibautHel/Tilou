using System;
using System.Collections.Generic;
using UnityEngine;



public class Shoot : MonoBehaviour
{
    [SerializeField] private Weapon weapon;
    void Update()
    {
        weapon.weapon.Firepoint.rotation = Camera.main.transform.rotation;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            weapon.weapon.Shoot();
        }
    }



    //List<Vector3> drawpts = new List<Vector3>();
    //Vector3 Pos => weapon.FirePoint.position;
    //Vector3 Vel => weapon.FirePoint.forward * weapon.Data.BulletSpeed;
    //public Vector3 acc => weapon.Data.Gravity;

    //private void OnDrawGizmos()
    //{
    //    drawpts.Clear();
    //    for (int i = 0; i < 80; i++)
    //    {
    //        float t = i / 79f;
    //        float time = t * 5;
    //        drawpts.Add(GetPoint(time));
    //    }

    //    for (int i = 0; i < 79; i++)
    //    {
    //        Gizmos.color = Color.blue;
    //        Gizmos.DrawLine(drawpts[i], drawpts[i + 1]);
    //    }
    //}
}
