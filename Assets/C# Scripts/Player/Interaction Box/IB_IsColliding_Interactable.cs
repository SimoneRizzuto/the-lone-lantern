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

    protected virtual void Update()
    {
        collider.OverlapCollider(_zFilter, collidedObjs);
        
        // If no interactable objects.
        if (collidedObjs.Count == 0) return;
        if (collidedObjs.Find(x => x.GetComponent<OBJ_Characteristics>().IsInteractable == false)) return;
        
        // If 1 interactable object.
        if (collidedObjs.Count == 1)
        {
            Debug.Log($"Collided with: {collidedObjs[0].name}"); return;
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

        Debug.Log($"Object to interact w/: {closestObj.name}");               
    }
}
