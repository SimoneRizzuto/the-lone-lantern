using UnityEngine;

public class PRO_Attack : MonoBehaviour
{
    public Animator Animator;
    
    public PRO_PlayerHealthController PlayerHealthController;
    /// PlayerAnimationController
    /// GameStateController ??? (probably not, but we'll see)
    /// PlayerBufferController / PlayerAttackController ???
    ///     > will need a controller that stops movement, depending on how long attack was. 
    ///     > might just be implemented in the animation controller, we'll see
    ///     > 
    
    void Update()
    {
        var leftClickInput = Input.GetKeyDown(KeyCode.Mouse0); 
        var rightClickInput = Input.GetKeyDown(KeyCode.Mouse1);
        var middleClickInput = Input.GetKeyDown(KeyCode.Mouse2);
        var controlZInput = Input.GetKey(KeyCode.LeftControl) && Input.GetKey(KeyCode.Z);

        var noAttackInputs = !leftClickInput && !rightClickInput && !middleClickInput;

        if (noAttackInputs)
        {
            Animator.ResetTrigger("Light Attack");
            return;
        }
        if (PlayerHealthController.PlayerHealth.GetHealth() <= 0) { return; }
        
        if (leftClickInput)
        {
            // Check for animation still playing
            //if (animation == null) 
            // play animation
            Animator.SetTrigger("Light Attack");
            
            // Attack
            
            // Remove StaminaHealth
            PlayerHealthController.AccumulateHealth(-150f);
        }

        
        if (rightClickInput)
        {
            
        }

        if (middleClickInput)
        {
            
        }

        if (controlZInput)
        {
            PlayerHealthController.SetHealth(PlayerHealthController.PlayerHealth.MaxHealth);
        }
    }
}

// Input.GetKey(KeyCode.Mouse0) - Left   
// Input.GetKey(KeyCode.Mouse1) - Right  
// Input.GetKey(KeyCode.Mouse2) - Middle 
// Input.GetKey(KeyCode.Mouse3) - Thumb  
