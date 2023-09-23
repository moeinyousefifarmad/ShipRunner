
using UnityEngine;

public class EnemyExplosive : MonoBehaviour
{
    [SerializeField] private GameObject explodeSprite;

    [Header("Player detection info ")]
    [SerializeField] private Transform RaycastPos;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask PlayerLayer;
    [Header("Time info")]
    [SerializeField] private float delayExplode;
    [SerializeField] private float delayOnDestroying;
    private float explodeTimer;
    private float destroyingTimer;
    private bool canRunTimer;
    private bool isExploded;
    private PlayerController playerController;
    private Rigidbody2D rb2d;
    private void Awake()
    {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if(IsPlayerDetected())
            canRunTimer = true;

        if(canRunTimer)
            RunExplodeTimer();
        
        if(CanExplode())
            Explode();

        ChangeGravity();

        if(isExploded)  
            RunDestroyingTimer();
        
        if(destroyingTimer > delayOnDestroying)
            Destroy(gameObject);
    }

    private void Explode()
    {
        explodeSprite.SetActive(true);
        explodeTimer = 0;
        isExploded = true;
    }
    private bool CanExplode()
    {         
        if(explodeTimer > delayExplode)
            return true;
        else 
            return false;
    }

    private bool IsPlayerDetected()
    {
        return Physics2D.Raycast(RaycastPos.position , Vector2.left , rayDistance , PlayerLayer);
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

    private void RunExplodeTimer()
    {
        explodeTimer += Time.deltaTime;
    }

    private void RunDestroyingTimer()
    {
        destroyingTimer += Time.deltaTime;
    }

}
