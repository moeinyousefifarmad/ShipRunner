
using UnityEngine;

public class Enemy : MonoBehaviour
{

  private void OnTriggerEnter2D(Collider2D other)
  {
    if(other.gameObject.tag == "Player")
    {
        AudioManager.Instance.PlayerDieAudio();
        GameManager.instance.isPlayerDead = true;
    }

  }
}
