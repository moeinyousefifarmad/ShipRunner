using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb2d;
    [Header("Movement info")]
    [SerializeField] private float jumpPower;
    [SerializeField] private float runSpeed;
    [Header("Ground detection info")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] Transform groundCheck;
    [SerializeField] private float groundCheckRayDistance;
    

    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D> ();
    }
    private void Update()
    {
        Run();
        Jump();
        ChangeGravity();
        SetJumpPower();
    }
    private void Run()
    {
        rb2d.velocity = new Vector2(runSpeed , rb2d.velocity.y);
    }
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround())
            rb2d.velocity = new Vector2 (rb2d.velocity.x , jumpPower);
    }

    private bool isOnGround()
    {
        if(rb2d.gravityScale > 0 ){
            return Physics2D.Raycast(groundCheck.position, Vector2.down , groundCheckRayDistance , groundLayer);
        }
        else if(rb2d.gravityScale < 0){
            return Physics2D.Raycast(groundCheck.position, Vector2.up , groundCheckRayDistance , groundLayer);           
        }
        else
            return false;
    }
    private void ChangeGravity()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            rb2d.gravityScale = -rb2d.gravityScale;
        }
    }

    private void SetJumpPower()
    {
        if(rb2d.gravityScale > 0)
            jumpPower = math.abs(jumpPower);
        else if(rb2d.gravityScale < 0)   
            jumpPower = -math.abs(jumpPower);
    }

}
