
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

    [SerializeField] private float delayOnShooting;
    private float shootingTimer;

    private void Update()
    {
        shootingTimer += Time.deltaTime;

        if(IsPlayerDetected() && CanShoot())
            Shoot();
    }

    private void Shoot()
    {
      //  Instantiate(EnemyBulletProjectile , BulletRespawnPos.position , quaternion.identity , BulletHolder);
      Debug.Log("shoot");
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
}
