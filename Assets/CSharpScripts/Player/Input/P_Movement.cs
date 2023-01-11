using System.Collections.Generic;
using CSharpScripts;
using CSharpScripts.Constants;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class P_Movement : MonoBehaviour
{
    [SerializeField] GameObject player_obj;
    [SerializeField] Rigidbody2D player_rb2d;
    [SerializeField] Animator player_animator;

    [SerializeField] private float max_speed = 4;
    private readonly float moveSpeed = 4;
    private float xMovement, yMovement;

    private PlayerInput playerInput;
    
    void Start()
    {
        playerInput.SwitchCurrentActionMap("Luce Map");
        
        Physics2D.gravity = Vector2.zero;
        player_rb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        var currentGameState = GameObject.Find("PFB_StateManager").GetComponent<OBJ_GameState>().CurrentGameState;

        // => var isCollidingWithCutsceneTrigger = GameObject.FindObjectOfType<OBJ_IsColliding_CutsceneTrigger>().IsCollidingWithPlayer();
        // Change game state to cutscene
        //var isCollidingWithInteractableObject = GameObject.FindObjectOfType<IB_IsColliding_Interactable>().IsCollidingWithInteractable();
        
        //xMovement = 0;
        //yMovement = 0;

        /*player_rb2d.velocity = new Vector2(yMovement, xMovement);
        player_animator.SetFloat("Speed", 0);

        player_animator.SetBool("Up", false);
        player_animator.SetBool("Left", false);
        player_animator.SetBool("Down", false);
        player_animator.SetBool("Right", false);
        
        if (currentGameState is GameState.Interaction or GameState.Menu or GameState.Cutscene) return;*/
        
        
        
        /*if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            ResetMovement();
            return;
        }
        
        if (Input.GetKey(KeyCode.W))
        {
            yMovement = moveSpeed;
            player_rb2d.velocity += new Vector2(0, yMovement);
            player_animator.SetFloat("Speed", moveSpeed);
            player_animator.SetBool("Up", true);
            player_animator.SetInteger("LastDirection", 1);
        }
        if (Input.GetKey(KeyCode.A))
        {
            xMovement = -moveSpeed;
            player_rb2d.velocity += new Vector2(xMovement, 0);
            player_animator.SetFloat("Speed", moveSpeed);
            player_animator.SetBool("Left", true);
            player_animator.SetInteger("LastDirection", 2);
        }
        if (Input.GetKey(KeyCode.S))
        {
            yMovement = -moveSpeed;
            player_rb2d.velocity += new Vector2(0, yMovement);
            player_animator.SetFloat("Speed", moveSpeed);
            player_animator.SetBool("Down", true);
            player_animator.SetInteger("LastDirection", 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            xMovement = moveSpeed;  
            player_rb2d.velocity += new Vector2(xMovement, 0);
            player_animator.SetFloat("Speed", moveSpeed);
            player_animator.SetBool("Right", true);
            player_animator.SetInteger("LastDirection", 3);
        }

        
        
        
        // If multiple directions are held, stop in the spot.
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            xMovement = 0;
            yMovement = 0;
            player_animator.SetBool("Up", false);
            player_animator.SetBool("Down", false);
            player_animator.SetFloat("Speed", 0);

            if (Input.GetKey(KeyCode.A))
            {
                xMovement = -moveSpeed;
                player_animator.SetFloat("Speed", moveSpeed);
                player_animator.SetBool("Left", true);
                player_animator.SetInteger("LastDirection", 2);
            }
            if (Input.GetKey(KeyCode.D))
            {
                xMovement = moveSpeed;
                player_animator.SetFloat("Speed", moveSpeed);
                player_animator.SetBool("Right", true);
                player_animator.SetInteger("LastDirection", 3);
            }

            player_rb2d.velocity = new Vector2(xMovement, yMovement);
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            xMovement = 0;
            yMovement = 0;
            player_animator.SetBool("Left", false);
            player_animator.SetBool("Right", false);
            player_animator.SetFloat("Speed", 0);

            if (Input.GetKey(KeyCode.W))
            {
                yMovement = moveSpeed;
                player_animator.SetFloat("Speed", moveSpeed);
                player_animator.SetBool("Up", true);
                player_animator.SetInteger("LastDirection", 1);
            }
            if (Input.GetKey(KeyCode.S))
            {
                yMovement = -moveSpeed;
                player_animator.SetFloat("Speed", moveSpeed);
                player_animator.SetBool("Down", true);
                player_animator.SetInteger("LastDirection", 0);
            }

            player_rb2d.velocity = new Vector2(xMovement, yMovement);
        }*/

        // Keeps movement to maximum speed.
        LimitVelocityToMaxSpeed();
    }
    void LimitVelocityToMaxSpeed()
    {
        if (player_rb2d.velocity.magnitude > max_speed)
        {
            player_rb2d.velocity = player_rb2d.velocity.normalized * max_speed;
        }
    }
    void ResetMovement()
    {
        xMovement = 0;
        yMovement = 0;

        player_rb2d.velocity = new Vector2(yMovement, xMovement);
        player_animator.SetFloat("Speed", 0);

        player_animator.SetBool("Up", false);
        player_animator.SetBool("Left", false);
        player_animator.SetBool("Down", false);
        player_animator.SetBool("Right", false);
    }
    void OnMove(InputValue value)
    {
        xMovement = value.Get<Vector2>().x * max_speed; 
        yMovement = value.Get<Vector2>().y * max_speed;
        
        player_rb2d.velocity = new Vector2(xMovement, yMovement);
        player_animator.SetFloat("Speed", 0);

        player_animator.SetBool("Up", false);
        player_animator.SetBool("Left", false);
        player_animator.SetBool("Down", false);
        player_animator.SetBool("Right", false);
        
        player_animator.SetBool("Up", true);
        
        if (yMovement > 0) player_animator.SetBool("Up", true);
        if (xMovement < 0) player_animator.SetBool("Left", true);
        if (yMovement < 0) player_animator.SetBool("Down", true);
        if (xMovement > 0) player_animator.SetBool("Right", true);
        
        Debug.Log($"X: {value.Get<Vector2>().x}");
        Debug.Log($"Y: {value.Get<Vector2>().y}");
        //Debug.Log($"Action: {action}");
    }
}

