using CSharpScripts;
using CSharpScripts.Constants;
using UnityEngine;

namespace CSharp_Scripts.Player.Input
{
    public class P_Movement : MonoBehaviour
    {
        [SerializeField] GameObject player_obj;
        [SerializeField] Rigidbody2D player_rb2d;
        [SerializeField] Animator player_animator;

        [SerializeField] private float max_speed = 4;
        private float moveSpeed = 4;
        private float xMovement, yMovement;

        void Start()
        {
            Physics2D.gravity = Vector2.zero;
            player_rb2d = GetComponent<Rigidbody2D>();
        }

        private void FixedUpdate()
        {
            var currentGameState = GameObject.Find("PFB_StateManager").GetComponent<OBJ_GameState>().CurrentGameState;

            // => var isCollidingWithCutsceneTrigger = GameObject.FindObjectOfType<OBJ_IsColliding_CutsceneTrigger>().IsCollidingWithPlayer();
            // Change game state to cutscene

            //var isCollidingWithInteractableObject = GameObject.FindObjectOfType<IB_IsColliding_Interactable>().IsCollidingWithInteractable();

            if (currentGameState is GameState.Interaction or GameState.Menu or GameState.Cutscene)
            {
                xMovement = 0;
                yMovement = 0;

                player_rb2d.velocity = new Vector2(yMovement, xMovement);
                player_animator.SetFloat("Speed", 0);

                player_animator.SetBool("Up", false);
                player_animator.SetBool("Left", false);
                player_animator.SetBool("Down", false);
                player_animator.SetBool("Right", false);
            
                return;
            }

            if (UnityEngine.Input.GetKey(KeyCode.W) || UnityEngine.Input.GetKey(KeyCode.A) || UnityEngine.Input.GetKey(KeyCode.S) || UnityEngine.Input.GetKey(KeyCode.D))
            {
                if (UnityEngine.Input.GetKey(KeyCode.W))
                {
                    yMovement = moveSpeed;
                    player_rb2d.velocity += new Vector2(0, yMovement);
                    player_animator.SetFloat("Speed", moveSpeed);

                    player_animator.SetBool("Up", true);
                    player_animator.SetBool("Left", false);
                    player_animator.SetBool("Down", false);
                    player_animator.SetBool("Right", false);

                    player_animator.SetInteger("LastDirection", 1);
                }
                if (UnityEngine.Input.GetKey(KeyCode.A))
                {
                    xMovement = -moveSpeed;
                    player_rb2d.velocity += new Vector2(xMovement, 0);
                    player_animator.SetFloat("Speed", moveSpeed);

                    player_animator.SetBool("Left", true);
                    if (!UnityEngine.Input.GetKey(KeyCode.W))
                    {
                        player_animator.SetBool("Up", false);
                    }
                    if (!UnityEngine.Input.GetKey(KeyCode.S))
                    {
                        player_animator.SetBool("Down", false);
                    }
                    player_animator.SetBool("Right", false);

                    player_animator.SetInteger("LastDirection", 2);
                }
                if (UnityEngine.Input.GetKey(KeyCode.S))
                {
                    yMovement = -moveSpeed;
                    player_rb2d.velocity += new Vector2(0, -moveSpeed);
                    player_animator.SetFloat("Speed", moveSpeed);

                    player_animator.SetBool("Down", true);
                    player_animator.SetBool("Up", false);
                    player_animator.SetBool("Left", false);
                    player_animator.SetBool("Right", false);

                    player_animator.SetInteger("LastDirection", 0);
                }
                if (UnityEngine.Input.GetKey(KeyCode.D))
                {
                    xMovement = moveSpeed;
                    player_rb2d.velocity += new Vector2(xMovement, 0);
                    player_animator.SetFloat("Speed", moveSpeed);

                    player_animator.SetBool("Right", true);
                    if (!UnityEngine.Input.GetKey(KeyCode.W))
                    {
                        player_animator.SetBool("Up", false);
                    }
                    if (!UnityEngine.Input.GetKey(KeyCode.S))
                    {
                        player_animator.SetBool("Down", false);
                    }
                    player_animator.SetBool("Left", false);

                    player_animator.SetInteger("LastDirection", 3);
                }
            }
            else
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

            // If multiple directions are held, stop in the spot.
            if (UnityEngine.Input.GetKey(KeyCode.W) && UnityEngine.Input.GetKey(KeyCode.S))
            {
                xMovement = 0;
                yMovement = 0;

                player_animator.SetBool("Up", false);
                player_animator.SetBool("Down", false);
                player_animator.SetFloat("Speed", 0);

                if (UnityEngine.Input.GetKey(KeyCode.A))
                {
                    xMovement = -moveSpeed;
                    player_animator.SetFloat("Speed", moveSpeed);
                    player_animator.SetBool("Left", true);
                    player_animator.SetInteger("LastDirection", 2);
                }
                else if (UnityEngine.Input.GetKey(KeyCode.D))
                {
                    xMovement = moveSpeed;
                    player_animator.SetFloat("Speed", moveSpeed);
                    player_animator.SetBool("Right", true);
                    player_animator.SetInteger("LastDirection", 3);
                }

                player_rb2d.velocity = new Vector2(xMovement, yMovement);
            }
            else if (UnityEngine.Input.GetKey(KeyCode.A) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                xMovement = 0;
                yMovement = 0;

                player_animator.SetBool("Left", false);
                player_animator.SetBool("Right", false);
                player_animator.SetFloat("Speed", 0);

                if (UnityEngine.Input.GetKey(KeyCode.W))
                {
                    yMovement = moveSpeed;
                    player_animator.SetFloat("Speed", moveSpeed);
                    player_animator.SetBool("Up", true);
                    player_animator.SetInteger("LastDirection", 1);
                }
                else if (UnityEngine.Input.GetKey(KeyCode.S))
                {
                    yMovement = -moveSpeed;
                    player_animator.SetFloat("Speed", moveSpeed);
                    player_animator.SetBool("Down", true);
                    player_animator.SetInteger("LastDirection", 0);
                }

                player_rb2d.velocity = new Vector2(xMovement, yMovement);
            }

            if (UnityEngine.Input.GetKey(KeyCode.W) && UnityEngine.Input.GetKey(KeyCode.S) && UnityEngine.Input.GetKey(KeyCode.A) && UnityEngine.Input.GetKey(KeyCode.D))
            {
                xMovement = 0;
                yMovement = 0;

                player_rb2d.velocity = new Vector2(yMovement, xMovement);
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
}
