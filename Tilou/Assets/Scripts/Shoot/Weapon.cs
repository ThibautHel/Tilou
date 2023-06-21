using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Weapons/PlasmaWeapon")]
public class Weapon : ScriptableObject
{
    [SerializeField] public WeaponHandler weapon;
}
