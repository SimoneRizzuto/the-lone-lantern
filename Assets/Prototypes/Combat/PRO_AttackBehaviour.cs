using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRO_AttackBehaviour : StateMachineBehaviour
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        // Change player state to IsAttacking
        
        // NOTE: add a ObjectCombatState script that is held by every character object that contributes to combat.
        // This ObjectCombatState script will use an interface, probably called ObjectState, that holds
        // generic states for multiple objects. 
        // - IsCharacter
        // - IsAttackable
        // 
        
    }
}
