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
}
