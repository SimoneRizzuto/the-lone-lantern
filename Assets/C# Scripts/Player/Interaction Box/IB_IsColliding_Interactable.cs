using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IB_IsColliding_Interactable : MonoBehaviour
{
    [SerializeField] private ContactFilter2D _zFilter;
    private Collider2D collider;
    private List<Collider2D> collidedObjs = new List<Collider2D>(1);
    private GameObject interactableBoxObj;

    protected virtual void Start()
    {
        collider = GetComponent<Collider2D>();
        interactableBoxObj = GameObject.Find("PFB_Player/InteractionBox");
    }

    /* protected virtual void Update()
    {
        
    } */

    public Collider2D IsCollidingWithInteractable()
    {
        collider.OverlapCollider(_zFilter, collidedObjs);
        
        // If no interactable objects.
        if (collidedObjs.Count == 0) return new Collider2D();
        if (collidedObjs.Find(x => x.GetComponent<OBJ_Characteristics>().IsInteractable == false)) return new Collider2D();
        
        // If 1 interactable object.
        if (collidedObjs.Count == 1)
        {
            return collidedObjs[0];
        }
        
        // If x > 1 interactable objects.
        Collider2D closestObj = null;
        foreach (var obj in collidedObjs)
        {
            if (closestObj == null){ closestObj = obj; continue; }

            // Find the closest interactable object to the IB.
            float currentObjDistance = (obj.transform.position - interactableBoxObj.transform.position).magnitude;
            float closestObjSoFarDistance = (closestObj.transform.position - interactableBoxObj.transform.position).magnitude;
            
            if (closestObjSoFarDistance > currentObjDistance ) closestObj = obj;
        }

        return closestObj;
    }
}
