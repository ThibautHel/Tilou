using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour, IHealth
{   
    // -- VARIABLES

    [SerializeField] private float currentHealth;

    // -- PROPERTIES

    public float MaxHealth { get; private set; } = 100f;
    public float CurrentHealth {
        get
        {
            return currentHealth;
        }
        set
        {
            currentHealth = value;
            if( currentHealth <= 0 )
            {
                Die();
            }
        }
    }

    // -- METHODS

    private void Die()
    {
        Destroy(gameObject);
    }

    public void TakeDmg(
        float Dmg
        )
    {
        CurrentHealth -= Dmg;
    }

    // -- UNITY

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }
}
