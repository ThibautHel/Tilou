using UnityEngine;

[CreateAssetMenu(menuName = "Weapons/PlasmaWeapon")]
public class Weapon : ScriptableObject
{
    //[SerializeField] public WeaponHandler weapon;
    //public Transform Firepoint;
    [SerializeField] public BulletData BulletData;
    [SerializeField] private GameObject weaponVFX;
    [SerializeField] public float OverheatCeiling;
    [SerializeField] public float OverheatReloadTimer;
    [SerializeField] public float FireRate;
    [SerializeField] public float HeatPerShot;
    //[SerializeField] public float Damage;

    public GameObject WeaponVFX => weaponVFX;

    public void Shoot(Transform FirePoint, Vector3 dirToCameraRay, Vector3 cameraDir, Vector3 cameraPos)
    {
        Bullet bullet = Instantiate(BulletData.Bullet, FirePoint.position, Quaternion.LookRotation(dirToCameraRay.normalized, Vector3.up)).GetComponent<Bullet>();
        bullet.Initialize(BulletData, dirToCameraRay, cameraDir, cameraPos);
    }
}
