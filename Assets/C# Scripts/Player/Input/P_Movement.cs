using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_Movement : MonoBehaviour
{
    [SerializeField] GameObject player_obj;
    [SerializeField] Rigidbody2D player_rb2d;
    [SerializeField] Animator player_animator;

    private float move_speed = 4;
    [SerializeField] private float max_speed = 4;
    private float x_movement, y_movement;

    public bool movement_allowed;

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = Vector2.zero;
        player_rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per physics rotation
    private void FixedUpdate()
    {
        var isDialogueActive = GameObject.Find("PFB_CanvasUI").transform.GetChild(0).gameObject.activeSelf;

        // => var isCollidingWithCutsceneTrigger = GameObject.FindObjectOfType<OBJ_IsColliding_CutsceneTrigger>().IsCollidingWithPlayer();
        // Change game state to cutscene

        var isCollidingWithInteractableObject = GameObject.FindObjectOfType<IB_IsColliding_Interactable>().IsCollidingWithInteractable();

        if (isDialogueActive) 
        {
            x_movement = 0;
            y_movement = 0;

            player_rb2d.velocity = new Vector2(y_movement, x_movement);
            player_animator.SetFloat("Speed", 0);

            player_animator.SetBool("Up", false);
            player_animator.SetBool("Left", false);
            player_animator.SetBool("Down", false);
            player_animator.SetBool("Right", false);
            
            return;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.W))
            {
                y_movement = move_speed;
                player_rb2d.velocity += new Vector2(0, y_movement);
                player_animator.SetFloat("Speed", move_speed);

                player_animator.SetBool("Up", true);
                player_animator.SetBool("Left", false);
                player_animator.SetBool("Down", false);
                player_animator.SetBool("Right", false);

                player_animator.SetInteger("LastDirection", 1);
            }
            if (Input.GetKey(KeyCode.A))
            {
                x_movement = -move_speed;
                player_rb2d.velocity += new Vector2(x_movement, 0);
                player_animator.SetFloat("Speed", move_speed);

                player_animator.SetBool("Left", true);
                if (!Input.GetKey(KeyCode.W))
                {
                    player_animator.SetBool("Up", false);
                }
                if (!Input.GetKey(KeyCode.S))
                {
                    player_animator.SetBool("Down", false);
                }
                player_animator.SetBool("Right", false);

                player_animator.SetInteger("LastDirection", 2);
            }
            if (Input.GetKey(KeyCode.S))
            {
                y_movement = -move_speed;
                player_rb2d.velocity += new Vector2(0, -move_speed);
                player_animator.SetFloat("Speed", move_speed);

                player_animator.SetBool("Down", true);
                player_animator.SetBool("Up", false);
                player_animator.SetBool("Left", false);
                player_animator.SetBool("Right", false);

                player_animator.SetInteger("LastDirection", 0);
            }
            if (Input.GetKey(KeyCode.D))
            {
                x_movement = move_speed;
                player_rb2d.velocity += new Vector2(x_movement, 0);
                player_animator.SetFloat("Speed", move_speed);

                player_animator.SetBool("Right", true);
                if (!Input.GetKey(KeyCode.W))
                {
                    player_animator.SetBool("Up", false);
                }
                if (!Input.GetKey(KeyCode.S))
                {
                    player_animator.SetBool("Down", false);
                }
                player_animator.SetBool("Left", false);

                player_animator.SetInteger("LastDirection", 3);
            }
        }
        else
        {
            x_movement = 0;
            y_movement = 0;

            player_rb2d.velocity = new Vector2(y_movement, x_movement);
            player_animator.SetFloat("Speed", 0);

            player_animator.SetBool("Up", false);
            player_animator.SetBool("Left", false);
            player_animator.SetBool("Down", false);
            player_animator.SetBool("Right", false);
        }

        // If multiple directions are held, stop in the spot.
        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
        {
            x_movement = 0;
            y_movement = 0;

            player_animator.SetBool("Up", false);
            player_animator.SetBool("Down", false);
            player_animator.SetFloat("Speed", 0);

            if (Input.GetKey(KeyCode.A))
            {
                x_movement = -move_speed;
                player_animator.SetFloat("Speed", move_speed);
                player_animator.SetBool("Left", true);
                player_animator.SetInteger("LastDirection", 2);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                x_movement = move_speed;
                player_animator.SetFloat("Speed", move_speed);
                player_animator.SetBool("Right", true);
                player_animator.SetInteger("LastDirection", 3);
            }

            player_rb2d.velocity = new Vector2(x_movement, y_movement);
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            x_movement = 0;
            y_movement = 0;

            player_animator.SetBool("Left", false);
            player_animator.SetBool("Right", false);
            player_animator.SetFloat("Speed", 0);

            if (Input.GetKey(KeyCode.W))
            {
                y_movement = move_speed;
                player_animator.SetFloat("Speed", move_speed);
                player_animator.SetBool("Up", true);
                player_animator.SetInteger("LastDirection", 1);
            }
            else if (Input.GetKey(KeyCode.S))
            {
                y_movement = -move_speed;
                player_animator.SetFloat("Speed", move_speed);
                player_animator.SetBool("Down", true);
                player_animator.SetInteger("LastDirection", 0);
            }

            player_rb2d.velocity = new Vector2(x_movement, y_movement);
        }

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
        {
            x_movement = 0;
            y_movement = 0;

            player_rb2d.velocity = new Vector2(y_movement, x_movement);
            player_animator.SetFloat("Speed", 0);
            player_animator.SetInteger("LastDirection", 0);

            player_animator.SetBool("Up", false);
            player_animator.SetBool("Left", false);
            player_animator.SetBool("Down", false);
            player_animator.SetBool("Right", false);
        }

        // Keeps movement to maximum speed.
        if (player_rb2d.velocity.magnitude > max_speed)
        {
            player_rb2d.velocity = player_rb2d.velocity.normalized * max_speed;
        }
    }
}
