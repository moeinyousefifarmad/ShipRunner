
using Unity.Mathematics;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    [Header("Bullet instantiate info ")]
    [SerializeField] private GameObject EnemyBulletProjectile;
    [SerializeField] private Transform BulletRespawnPos;
    [SerializeField] private Transform BulletHolder;
    [Header("Player detection info ")]
    [SerializeField] private Transform RaycastPos;
    [SerializeField] private float rayDistance;
    [SerializeField] private LayerMask PlayerLayer;
    [Header("Shooting info")]
    [SerializeField] private float delayOnShooting;
    [SerializeField] private float forcePlayerJumpPower;
    private float shootingTimer;
    private Rigidbody2D rb2d;
    private PlayerController playerController;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        shootingTimer += Time.deltaTime;

        if(IsPlayerDetected() && CanShoot())
            Shoot();
    }

    private void Shoot()
    {
        Instantiate(EnemyBulletProjectile , BulletRespawnPos.position , quaternion.identity , BulletHolder);
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

    private bool CanShoot()
    {
        if(shootingTimer > delayOnShooting)
        {
            shootingTimer = 0;
            return true;
        }
        else 
            return false;
    }

    private void ForcePlayerJumpOnHitting(Collision2D playerCollision)
    {
        playerController = playerCollision.collider.gameObject.GetComponent<PlayerController>();
        if(playerController.rb2d.gravityScale > 0)
            playerController.rb2d.velocity = new Vector2(rb2d.velocity.x , forcePlayerJumpPower);
        else if(playerController.rb2d.gravityScale < 0) 
            playerController.rb2d.velocity = new Vector2(rb2d.velocity.x , -forcePlayerJumpPower);
    }

    private void FallOnHit(Collision2D playerCollision)
    {
        playerController = playerCollision.collider.gameObject.GetComponent<PlayerController>();
        if(playerController.rb2d.gravityScale > 0)
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            rb2d.gravityScale = 5;
        }
        else if(playerController.rb2d.gravityScale < 0)
        {
            rb2d.bodyType = RigidbodyType2D.Dynamic;
            rb2d.gravityScale = -5;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            FallOnHit(collision);
            ForcePlayerJumpOnHitting(collision);
        }
    }

}   
