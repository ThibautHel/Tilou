using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Weapons/PlasmaWeapon")]
public class Weapon : ScriptableObject
{
    //[SerializeField] public WeaponHandler weapon;
    //public Transform Firepoint;
    [SerializeField] private BulletData BulletData;
    [SerializeField] private GameObject weaponVFX;
    [SerializeField] public float OverheatCeiling;
    [SerializeField] public float OverheatReloadTimer;
    [SerializeField] public float FireRate;
    [SerializeField] public float HeatPerShot;

    public GameObject WeaponVFX => weaponVFX;

    public void Shoot(Transform FirePoint)
    {
        Bullet bullet = Instantiate(BulletData.Bullet, FirePoint.position, Camera.main.transform.rotation).GetComponent<Bullet>();
        bullet.Initialize(speed: BulletData.BulletSpeed, gravity: BulletData.Gravity.y);
    }
}
