using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Transform Firepoint;
    [SerializeField] private BulletData BulletData;
    [SerializeField] private GameObject VFX;   

    public void Shoot()
    {
        BulletData.Shoot(Firepoint);
    }
}
