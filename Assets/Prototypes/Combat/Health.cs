using System;
using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    public readonly float MaxHealth = 1000f;
    public float CurrentHealth { get; set; } = 1000f; 

    private void Start()
    {
        CurrentHealth = 1000f;
    }

    void HealthCheck(float h = float.NaN)
    {
        float healthToCheck = h;
        
        if (float.IsNaN(healthToCheck))
        {
            healthToCheck = CurrentHealth;
        }
        
        if (healthToCheck > MaxHealth) { CurrentHealth = MaxHealth; }
    }
    
    public float SetHealth(float newHealth)
    {
        CurrentHealth = newHealth;
        HealthCheck();
        return CurrentHealth;
    }

    public float AccumulateHealth(float accumulativeHealth)
    {
        CurrentHealth += accumulativeHealth;
        HealthCheck();
        return CurrentHealth;
    }

    public float GetHealth()
    {
        return CurrentHealth;
    }
}
