
using UnityEngine;

public class EnemyExplosive : MonoBehaviour
{
    [Header("Player detection info ")]
    [SerializeField] private Transform RaycastPos;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask PlayerLayer;

    [SerializeField] private float delayExplode;
    private PlayerController playerController;
    private Rigidbody2D rb2d;
    private float explodeTimer;

    private void Awake()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        explodeTimer += Time.deltaTime;
        if(CanExplode())
            Explode();
        ChangeGravity();
    }

    private void Explode()
    {
        Debug.Log("Explode");
        // enable trigger collision 
        // run animation 
    }
    private bool CanExplode()
    {
        if( Physics2D.Raycast(RaycastPos.position , Vector2.left , rayDistance , PlayerLayer) && 
        explodeTimer > delayExplode)
            return true;
        else 
            return false;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(RaycastPos.position , new Vector3(RaycastPos.position.x - rayDistance ,
         RaycastPos.position.y , RaycastPos.position.z));
    }

    private void ChangeGravity()
    {
        if(playerController.rb2d.gravityScale > 0)
            this.rb2d.gravityScale = Mathf.Abs(rb2d.gravityScale);
        else if(playerController.rb2d.gravityScale < 0)
            this.rb2d.gravityScale = - Mathf.Abs(rb2d.gravityScale);
    }
}
