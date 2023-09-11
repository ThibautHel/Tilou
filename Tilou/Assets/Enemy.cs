using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IHealth
{
    public UnitStats Stats;
    public float currentHealth = 0f;

    public float CurrentHealth { get; private set; }

    public float MaxHealth { get; private set; }

    public void TakeDmg(float Dmg)
    {
        currentHealth -= Dmg;
        Debug.Log("Took " + Dmg + "Damages");
    }

    private void Start()
    {
        MaxHealth = Stats.maxHealth;
        currentHealth = MaxHealth;
    }


    private void OnCollisionEnter(Collision collision)
    {
        TakeDmg(AnimationManager.Instance.CurrentAnimData.Damages);
    }
}
