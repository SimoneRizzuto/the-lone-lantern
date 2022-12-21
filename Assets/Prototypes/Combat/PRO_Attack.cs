using UnityEngine;
using UnityEngine.Serialization;

public class PRO_Attack : MonoBehaviour
{
    public PRO_PlayerHealthController PlayerHealthController;
    void Update()
    {
        if (Input.GetKey(KeyCode.None)) { return; }

        if (Input.GetKeyUp(KeyCode.Mouse0)) // Left click
        {
            // Check for animation still playing
            //if (animation == null)
            
            // Attack
            
            // Remove StaminaHealth
            PlayerHealthController.AccumulateHealth(-10);
        }

        if (Input.GetKeyDown(KeyCode.Mouse1)) // Right click
        {
            
        }
        
        if (Input.GetKeyDown(KeyCode.Mouse2)) // Middle click
        {
            
        }
        
        if (Input.GetKeyDown(KeyCode.LeftControl) && Input.GetKey(KeyCode.Z)) // Ctrl+Z
        {
            PlayerHealthController.SetHealth(PlayerHealthController.PlayerHealth.MaxHealth);
        }
    }
}

// Input.GetKey(KeyCode.Mouse0) - Left   
// Input.GetKey(KeyCode.Mouse1) - Right  
// Input.GetKey(KeyCode.Mouse2) - Middle 
// Input.GetKey(KeyCode.Mouse3) - Thumb  
