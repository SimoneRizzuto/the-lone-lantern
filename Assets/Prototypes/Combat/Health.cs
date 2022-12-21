using UnityEngine;
using UnityEngine.Serialization;

public class Health : MonoBehaviour
{
    public readonly float MaxHealth = 100f;
    public float CurrentHealth = 100f;

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
