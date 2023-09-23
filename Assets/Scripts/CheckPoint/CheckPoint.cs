
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            GameManager.instance.haveCheckPoint = true;
            GameManager.instance.lastCheckPointPosition = this.transform.position;
            GameManager.instance.LastGravityScale = other.gameObject.GetComponent<Rigidbody2D>().gravityScale;
        }
    }

}
