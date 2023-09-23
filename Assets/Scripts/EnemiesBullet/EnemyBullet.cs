
using Unity.VisualScripting;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb2d;

    GameManager gameManager;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        Move();

    }
    private void Move()
    {
        rb2d.velocity = new Vector2(-speed , rb2d.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.isPlayerDead = true;
        }
    }
}
