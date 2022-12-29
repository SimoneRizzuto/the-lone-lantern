using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PRO_PlayerHealthController : MonoBehaviour
{
    public Slider SliderHealthBar;
    public Health PlayerHealth;

    private bool isRegenerating;
    private int bufferTimer = 0;
    private readonly int bufferTimerTrigger = 50 * 2; // 3 seconds

    void Start()
    {
        PlayerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        SliderHealthBar = GetComponent<Slider>();
        SliderHealthBar.maxValue = PlayerHealth.MaxHealth;
        SliderHealthBar.value = PlayerHealth.MaxHealth;
    }

    void FixedUpdate()
    {
        IncrementBuffer();
        
        if (IsRegenerating())
        {
            AccumulateHealth(15f);
        }
    }

    public void ResetRegeneration()
    {
        bufferTimer = 0;
        isRegenerating = false;
    }

    public void TriggerRegeneration()
    {
        isRegenerating = true;
    }

    public void StopRegeneration()
    {
        isRegenerating = false;
    }

    public void StartBufferIncrementation()
    {
        isRegenerating = true;
    }
    public void IncrementBuffer()
    {
        if (bufferTimer < bufferTimerTrigger)
        {
            isRegenerating = false;
            bufferTimer++;
            return;
        }

        TriggerRegeneration();
    }
    public bool IsRegenerating()
    {
        return isRegenerating;
    }
    
    public void SetHealth(float newHealth)
    {
        SliderHealthBar.value = PlayerHealth.SetHealth(newHealth);
    }

    public void AccumulateHealth(float accumulativeHealth)
    {
        if (accumulativeHealth < 0)
        {
            ResetRegeneration();
        }
        
        SliderHealthBar.value = PlayerHealth.AccumulateHealth(accumulativeHealth);
    }
}
