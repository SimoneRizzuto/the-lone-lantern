using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ_IsColliding_CutsceneTrigger : MonoBehaviour
{
    [SerializeField] private ContactFilter2D _zFilter;
    private Collider2D collider;
    private List<Collider2D> collidedObjs = new List<Collider2D>(1);
    //private GameObject interactableBoxObj;

    protected void Start()
    {
        collider = GetComponent<Collider2D>();
        //interactableBoxObj = GameObject.Find("PFB_Player/InteractionBox");
    }

    protected void Update()
    {
        if (IsCollidingWithCutsceneTrigger())
        {
            Debug.Log(IsCollidingWithCutsceneTrigger().name);
        }
    }

    public Collider2D IsCollidingWithCutsceneTrigger()
    {
        collider.OverlapCollider(_zFilter, collidedObjs);
        
        // If no objects are the player.
        if (collidedObjs.Count == 0) return new Collider2D();
        if (collidedObjs.Find(x => !x.GetComponent<OBJ_Characteristics>().IsPlayer)) return new Collider2D();

        // If the singular object is the player
        if (collidedObjs[0].GetComponent<OBJ_Characteristics>().IsPlayer)
        {
            return collidedObjs[0];
        }
        else
        {
            return new Collider2D();
        }
        
        // If no interactable objects.
        /*
        
        if (collidedObjs[0].name == "Player")
        {
            return collidedObjs[0];
        }
        else
        {
            return new Collider2D();
        } */

        /* // If 1 interactable object.
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
        } */

        
    }
}
