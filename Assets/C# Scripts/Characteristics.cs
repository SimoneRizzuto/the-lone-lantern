using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Characteristics : MonoBehaviour
{
    /// <summary>
    /// Signifies if an object can register an attack from another object.
    /// </summary>
    [SerializeField] public bool IsAttackable = false;
    /// <summary>
    /// Signifies if object can be interacted with.
    /// </summary>
    [SerializeField] public bool IsInteractable = false;
    /// <summary>
    /// Signifies if object can or cannot have other objects pass through it. (NOTE: Both objects have to be solid)
    /// </summary>
    [SerializeField] public bool IsSolid = false;
    /// <summary>
    /// Signifies if object is in the air.
    /// </summary>
    [SerializeField] public bool IsGrounded = false;
}
