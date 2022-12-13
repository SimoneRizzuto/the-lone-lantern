using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PRO_Movement : MonoBehaviour
{
    [SerializeField] GameObject player_obj;
    [SerializeField] Rigidbody2D player_rb2d;
    [SerializeField] Animator player_animator;

    private float moveSpeed = 4;
    [SerializeField] private float max_speed = 4;
    private float xMovement, yMovement;
    
    // Start is called before the first frame update
    void Start()
    {
        Physics2D.gravity = Vector2.zero;
        player_rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        
    }
}
