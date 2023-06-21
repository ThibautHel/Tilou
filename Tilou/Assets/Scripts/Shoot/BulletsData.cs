using System;
using UnityEngine;


[CreateAssetMenu(menuName = "Weapons/Plasma")]
public class BulletData : ScriptableObject
{
    public GameObject Bullet;
    public float BulletSpeed;
    public float TravelTime;
    public float Damages;
    public Vector3 Gravity;

    public void Shoot(Transform firePoint)
    {
        Bullet bullet = Instantiate(Bullet, firePoint.position, Camera.main.transform.rotation).GetComponent<Bullet>();
        bullet.Initialize(speed: BulletSpeed, gravity: Gravity.y);
    }
}
