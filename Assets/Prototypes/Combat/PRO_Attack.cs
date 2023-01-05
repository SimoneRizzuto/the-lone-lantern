using System.ComponentModel;
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

        var animationsPlaying = Animator.GetCurrentAnimatorClipInfo(0);
        
        if (animationsPlaying.Length != 0)
        {
            foreach (var anim in animationsPlaying)
            {
                if (anim.clip.name == "luce_attack_left_test") return;
                if (anim.clip.name == "luce_attack_up_test") return;
                if (anim.clip.name == "luce_attack_down_test") return;
                if (anim.clip.name == "luce_attack_right_test") return;
            }
        }
        
        if (noAttackInputs)
        {
            //Animator.ResetTrigger("Light Attack");
            
            //return;
        }
        if (PlayerHealthController.PlayerHealth.GetHealth() <= 0) { return; }
        
        if (leftClickInput)
        {
            if (Animator.GetBool("Up") || Animator.GetInteger("LastDirection") == 1) // 1
            {
                Animator.SetTrigger("Up");
                if (Animator.GetBool("Right"))
                {
                    Animator.SetTrigger("Right");
                }

                if (Animator.GetBool("Left"))
                {
                    Animator.SetTrigger("Left");
                }
            }

            if (Animator.GetBool("Down") || Animator.GetInteger("LastDirection") == 0) // 0
            {
                Animator.SetTrigger("Down");
                if (Animator.GetBool("Right"))
                {
                    Animator.SetTrigger("Right");
                }

                if (Animator.GetBool("Left"))
                {
                    Animator.SetTrigger("Left");
                }
            }
            
            if (Animator.GetBool("Left") || Animator.GetInteger("LastDirection") == 2) // 2
            {
                Animator.SetTrigger("Left");
            }

            if (Animator.GetBool("Right") || Animator.GetInteger("LastDirection") == 3) // 3
            {
                Animator.SetTrigger("Right");
            }

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
