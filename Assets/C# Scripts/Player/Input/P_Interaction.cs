using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Interaction : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            var test = GameObject.FindObjectOfType<IB_IsColliding_Interactable>().IsCollidingWithInteractable();

            Debug.Log($"{test.name} is the interactable object.s");
        }
    }
}
