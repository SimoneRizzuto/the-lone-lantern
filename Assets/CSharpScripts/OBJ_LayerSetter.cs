using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OBJ_LayerSetter : MonoBehaviour
{
    // Sets the distance of the object to the camera, so that everything has a layer.
    void Update()
    {
        gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.y);
    }
}
