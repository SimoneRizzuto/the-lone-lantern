using CSharpScripts;
using CSharpScripts.Constants;
using UnityEngine;

public class PRO_Movement : MonoBehaviour
{
    [SerializeField] GameObject PlayerObj;
    [SerializeField] Rigidbody2D PlayerRB2D;
    [SerializeField] Animator PlayerAnimator;

    [SerializeField] private readonly float MaxSpeed = 4;
    private protected float moveSpeed = 4;
    private float xMovement, yMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = Vector2.zero;
        PlayerRB2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        var currentGameState = GameObject.Find("PFB_StateManager").GetComponent<OBJ_GameState>().CurrentGameState;
        
        if (currentGameState is GameState.Interaction or GameState.Menu or GameState.Cutscene)
        {
            xMovement = 0;
            yMovement = 0;

            PlayerRB2D.velocity = new Vector2(yMovement, xMovement);
        }

        if (Input.GetKey(KeyCode.W))
        {
            yMovement = moveSpeed;
            
            PlayerRB2D.velocity = new Vector2(yMovement, xMovement);
        }
        if (Input.GetKey(KeyCode.A))
        {
            xMovement = -moveSpeed;
            PlayerRB2D.velocity += new Vector2(xMovement, 0);
        }
        if (Input.GetKey(KeyCode.S))
        {
            yMovement = -moveSpeed;
            PlayerRB2D.velocity += new Vector2(0, -moveSpeed);
        }
        if (Input.GetKey(KeyCode.D))
        {
            xMovement = moveSpeed;
            PlayerRB2D.velocity += new Vector2(xMovement, 0);
        }
        
        
        /*if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
        {
            
        }*/
    }
}
