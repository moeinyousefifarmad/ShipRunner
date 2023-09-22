using System.Collections;
using System.Collections.Generic;
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
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D> ();
    }
    private void Update()
    {
        Run();
        Jump();
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

    private bool isOnGround()=>Physics2D.Raycast(groundCheck.position, Vector2.down , groundCheckRayDistance , groundLayer);
    private void ChangeGravity(){}
}
