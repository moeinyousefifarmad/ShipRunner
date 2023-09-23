
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
    private AnimatorClipInfo[] clipInfo;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D> ();
    }
    private void Update()
    {
        Run();
        Jump();
        
        SetJumpPower();
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
            rb2d.velocity = new Vector2 (rb2d.velocity.x , jumpPower);
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
         //   if(GetCurrentClipName()=="idle" || GetCurrentClipName()=="rotateTo360")
             //   animator.SetTrigger("to180");
          //  else if(GetCurrentClipName()=="rotateTo180")
              //  animator.SetTrigger("to360");
        }
    }

    private void SetJumpPower()
    {
        if(rb2d.gravityScale > 0)
            jumpPower = math.abs(jumpPower);
        else if(rb2d.gravityScale < 0)   
            jumpPower = -math.abs(jumpPower);
    }

    private string GetCurrentClipName(){
        int layerIndex = 0;
        clipInfo = animator.GetCurrentAnimatorClipInfo(layerIndex); 
        return clipInfo[0].clip.name;
    }


}
