using System.Collections;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    [Header("Weapon")]
    [SerializeField] private Weapon CurrentWeapon;
    [SerializeField] private Transform WeaponHolder;
    private Transform FirePoint;

    [Header("Overheat")]

    [SerializeField] private float fireTimer;
    [SerializeField] private float currentOverheat;
    [SerializeField] private float CurrentOverheat
    {
        get => currentOverheat;
        set
        {
            currentOverheat = Mathf.Clamp( value, 0,CurrentWeapon.OverheatCeiling +1);
            if (CurrentOverheat <= 0)
            {
                OverheatLocked = false;
            }
        }
    }
    private float FireTimer
    {
        get
        {
            return Mathf.Clamp(fireTimer, 0, CurrentWeapon.FireRate);
        }
        set
        {
            fireTimer = value;
        }
    }
    private bool OverheatLocked = false;

    private Coroutine CurrentCoroutine;

    private void Start()
    {
        GameObject weapon = Instantiate(CurrentWeapon.WeaponVFX, WeaponHolder.transform.position, Quaternion.identity);
        weapon.transform.SetParent(WeaponHolder);
        FirePoint = weapon.GetComponent<WeaponGfx>().FirePoint;

    }
    void Update()
    {
        ShootInput();

        FireTimer += Time.deltaTime;
        CurrentOverheat -= CurrentWeapon.HeatPerShot * Time.deltaTime;
    }

    private void ShootInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) || Input.GetKey(KeyCode.Mouse0))
        {
            if (CurrentWeapon == null || OverheatLocked) { return; }

            FirePoint.rotation = Camera.main.transform.rotation;

            if (FireTimer != CurrentWeapon.FireRate)
            {
                return;
            }

            CurrentWeapon.Shoot(FirePoint);
            CurrentOverheat += CurrentWeapon.HeatPerShot;
            FireTimer = 0;

            if (CurrentOverheat > CurrentWeapon.OverheatCeiling)
            {
                OverheatLocked = true;
            }
        }
    }


    private IEnumerator OverheatCooldown()
    {
        yield return new WaitForSeconds(CurrentWeapon.OverheatReloadTimer);

        CurrentOverheat = 0f;
        OverheatLocked = false;
        CurrentCoroutine = null;
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
