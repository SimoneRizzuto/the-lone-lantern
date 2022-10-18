using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IB_Rotater : MonoBehaviour
{
    public enum Directions 
    {
        Up,
        Left,
        Down,
        Right
    } 
    public string CurrentlyFacingDirection { get; set; } = Directions.Up.ToString();

    public float xPosition = 0; public float yPosition = 0;
    public float rotation = 0;
    public float NeutralPosition = 0;
    public float InFrontPosition = 0;
    private float _distanceToFloor = 1f;
    
    void Update()
    {
        var playerSpriteName = this.gameObject.GetComponent<SpriteRenderer>().sprite.name;
        if (playerSpriteName.Contains("up") || playerSpriteName.Contains("Up"))
        {
            // + on the Y-axis in a straight line from his feet
            ObjectInFrontOfPlayer(Directions.Up.ToString());
        }
        if (playerSpriteName.Contains("left") || playerSpriteName.Contains("Left"))
        {
            // - on the X-axis
            ObjectInFrontOfPlayer(Directions.Left.ToString());
        }
        if (playerSpriteName.Contains("down") || playerSpriteName.Contains("Down"))
        {
           // - on the Y-axis
           ObjectInFrontOfPlayer(Directions.Down.ToString());
        }
        if (playerSpriteName.Contains("right") || playerSpriteName.Contains("Right"))
        {
            // + on the X-axis
            ObjectInFrontOfPlayer(Directions.Right.ToString());
        }
    }

    /// <summary>
    /// Rotates interaction hitbox depending on where the player is facing.
    /// </summary>
    private void ObjectInFrontOfPlayer(string direction)
    {
        InFrontPosition = 0; NeutralPosition = 0;
        float distanceInFrontToCheck = 0.5f;

        if (direction == Directions.Up.ToString())
        {
            NeutralPosition = this.gameObject.transform.position.x;// - 1f;
            InFrontPosition = this.gameObject.transform.position.y + distanceInFrontToCheck - _distanceToFloor + 0.65f;

            xPosition = NeutralPosition;
            yPosition = InFrontPosition;
            rotation = 0;
        }
        if (direction == Directions.Left.ToString())
        {
            InFrontPosition = this.gameObject.transform.position.x - distanceInFrontToCheck - 0.4f;
            NeutralPosition = this.gameObject.transform.position.y - _distanceToFloor + 0.22f;

            xPosition = InFrontPosition;
            yPosition = NeutralPosition;
            rotation = 90;
        }
        if (direction == Directions.Down.ToString())
        {
            NeutralPosition = this.gameObject.transform.position.x;
            InFrontPosition = this.gameObject.transform.position.y - distanceInFrontToCheck - _distanceToFloor;
            
            xPosition = NeutralPosition;
            yPosition = InFrontPosition;
            rotation = 0;
        }
        if (direction == Directions.Right.ToString())
        {
            InFrontPosition = this.gameObject.transform.position.x + distanceInFrontToCheck + 0.4f;
            NeutralPosition = this.gameObject.transform.position.y - _distanceToFloor + 0.22f;

            xPosition = InFrontPosition;
            yPosition = NeutralPosition;
            rotation = 90;
        }
    }
}
