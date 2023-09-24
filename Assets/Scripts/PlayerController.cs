
using Unity.Mathematics;

using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Movement info")]
    [SerializeField] private float jumpPower;
    [SerializeField] private float runSpeed;
    [Header("Ground detection info")]
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] Transform groundDownCheck;
    [SerializeField] Transform groundTopCheck;
    [SerializeField] private float groundCheckRayDistance;
    
    public Rigidbody2D rb2d;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    
    private void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D> ();
        animator  = GetComponentInChildren<Animator> ();
    }

    private void Start()
    {
        if(GameManager.instance.haveCheckPoint)
        {
            rb2d.gravityScale = GameManager.instance.LastGravityScale;
            transform.position = GameManager.instance.lastCheckPointPosition;
        }
    }
    private void Update()
    {
        SetSptireRender();
        Run();
        Jump();       
        SetJumpPower();
        AnimationSetUp();
    }

    private void LateUpdate()
    {
        ChangeGravity();
    }
    private void Run()
    {
        rb2d.velocity = new Vector2(runSpeed , rb2d.velocity.y);
    }
    private void Jump()
    {
        if(Input.GetKeyDown(KeyCode.Space) && isOnGround())
        {
            rb2d.velocity = new Vector2 (rb2d.velocity.x , jumpPower);
            AudioManager.Instance.PlayJumpAudio();
        }
    }

    private bool isOnGround()
    {
        if(rb2d.gravityScale > 0 ){
            return Physics2D.Raycast(groundDownCheck.position, Vector2.down , groundCheckRayDistance , groundLayer);
        }
        else if(rb2d.gravityScale < 0){
            return Physics2D.Raycast(groundTopCheck.position, Vector2.up , groundCheckRayDistance , groundLayer);           
        }
        else
            return false;
    }
    private void ChangeGravity()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            rb2d.gravityScale = -rb2d.gravityScale;
            animator.SetBool("isGravityChange" , true);
            AudioManager.Instance.PlayChangeGravityAudio();
        }
    }

    private void SetJumpPower()
    {
        if(rb2d.gravityScale > 0)
            jumpPower = math.abs(jumpPower);
        else if(rb2d.gravityScale < 0)   
            jumpPower = -math.abs(jumpPower);
    }

    private void AnimationSetUp()
    {
        animator.SetBool("isOnGround", isOnGround());
        animator.SetFloat("yVelocity", rb2d.velocity.y);
    }

    private void SetSptireRender()
    {
        if(Physics2D.Raycast(groundDownCheck.position, Vector2.down , groundCheckRayDistance , groundLayer))
            {
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
            }
        else if(Physics2D.Raycast(groundTopCheck.position, Vector2.up , groundCheckRayDistance , groundLayer))
        {
           // spriteRenderer.flipX = true;
            spriteRenderer.flipY = true;
        }
    }
}
