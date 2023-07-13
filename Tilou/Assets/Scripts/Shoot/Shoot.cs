using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class Shoot : MonoBehaviour
{
    // -- VARIABLES

    [Header("Weapon")]
    [SerializeField] private Weapon CurrentWeapon;
    [SerializeField] private Transform WeaponHolder;
    [SerializeField] private LayerMask ShootIgnoreLayer;
    private Transform FirePoint;

    [Header("Overheat")]

    [SerializeField] private float fireTimer;
    [SerializeField] private float currentOverheat;
    private bool OverheatLocked = false;

    // -- PROPERTIES
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

            if (FireTimer != CurrentWeapon.FireRate)
            {
                return;
            }

            Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hitInfo, 500f,ShootIgnoreLayer);
            Debug.DrawLine(Camera.main.transform.position, hitInfo.point,Color.red,20);
            Vector3 dirFromFirepointToRaycast = (hitInfo.point - FirePoint.position);
            Debug.DrawRay(FirePoint.position, dirFromFirepointToRaycast*100,Color.blue,20);
            Vector3 cameraDir = Camera.main.transform.forward;
            Vector3 cameraPos = Camera.main.transform.position;
            CurrentWeapon.Shoot(FirePoint, dirFromFirepointToRaycast ,cameraDir , cameraPos);
            CurrentOverheat += CurrentWeapon.HeatPerShot;
            FireTimer = 0;

            if (CurrentOverheat > CurrentWeapon.OverheatCeiling)
            {
                OverheatLocked = true;
            }
        }
    }

    //List<Vector3> drawpts = new List<Vector3>();
    //Vector3 Pos => FirePoint.position;
    //Vector3 Vel => FirePoint.forward * CurrentWeapon.BulletData.BulletSpeed;
    //public Vector3 acc => CurrentWeapon.BulletData.Gravity;

  //  private void OnDrawGizmos()
  //  {
        //drawpts.Clear();
        //for (int i = 0; i < 80; i++)
        //{
        //    float t = i / 79f;
        //    float time = t * 5;
        //    drawpts.Add(GetPoint(time));
        //}

        //for (int i = 0; i < 79; i++)
        //{
        //    Gizmos.color = Color.blue;
        //    Gizmos.DrawLine(drawpts[i], drawpts[i + 1]);
        //}

    //}

    //private Vector3 GetPoint(float time)
    //{
    //    return Pos + Vel * time + 0.5f * acc * time * time;
    //}
}
