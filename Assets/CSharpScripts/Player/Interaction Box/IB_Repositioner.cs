using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IB_Repositioner : MonoBehaviour
{
    public float xAxis { get; set; }
    public float yAxis { get; set; }

    string objectName = null;
    GameObject player = null;

    float currentRotation = 0;

    void Start()
    {
        xAxis = gameObject.transform.position.x;
        yAxis = gameObject.transform.position.y;

        objectName = GameObject.Find("Player").name;
        player = GameObject.Find("Player");
        Debug.Log($"Object name: {objectName}");
    }

    void Update()   
    {
        var x = player.GetComponent<IB_Rotater>().xPosition;
        var y = player.GetComponent<IB_Rotater>().yPosition;
        var position = gameObject.transform.position = new Vector2 (x, y);

        var rotation = player.GetComponent<IB_Rotater>().rotation;
        gameObject.transform.eulerAngles = new Vector3(
            gameObject.transform.eulerAngles.x,
            gameObject.transform.eulerAngles.y,
            rotation
        );
    }
}
