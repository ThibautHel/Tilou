using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour
{
    public Transform WeaponHolder;
    public List<Collider> Colliders = new List<Collider>();
    public List<GameObject> TargetHit = new List<GameObject>();

    private void Start()
    {
        Collider[] colliders = GetComponentsInChildren<Collider>();

        foreach (Collider col in colliders)
        {
            Colliders.Add(col);
        }
    }

    public void SetNewWaepon(GameObject newWeapon)
    {
        Colliders.Clear();
        GameObject NewWeapon = Instantiate(newWeapon);
        NewWeapon.transform.parent = WeaponHolder;
        Collider[] colliders = GetComponentsInChildren<Collider>();
        foreach (Collider col in colliders)
        {
            Colliders.Add(col);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.TryGetComponent(out IHealth health) && !TargetHit.Contains(collision.gameObject))
        {
            health.TakeDmg(AnimationManager.Instance.CurrentAnimData.Damages);
            TargetHit.Add(collision.gameObject);
        }

        Debug.Log("TEST WEAPON COLLIDEr");
    }

    public void ResetTargetHit()
    {
        TargetHit.Clear();
    }
}
