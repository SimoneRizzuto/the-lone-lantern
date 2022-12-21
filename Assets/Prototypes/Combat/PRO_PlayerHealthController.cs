using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PRO_PlayerHealthController : MonoBehaviour
{
    public Slider SliderHealthBar;
    public Health PlayerHealth;

    void Start()
    {
        PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        SliderHealthBar = GetComponent<Slider>();
        SliderHealthBar.maxValue = PlayerHealth.MaxHealth;
        SliderHealthBar.value = PlayerHealth.MaxHealth;
    }

    public void SetHealth(float newHealth)
    {
        SliderHealthBar.value = PlayerHealth.SetHealth(newHealth);
    }

    public void AccumulateHealth(float accumulativeHealth)
    {
        SliderHealthBar.value = PlayerHealth.AccumulateHealth(accumulativeHealth);
    }
}
