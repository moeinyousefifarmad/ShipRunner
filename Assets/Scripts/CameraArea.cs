
using UnityEngine;

public class CameraArea : MonoBehaviour
{


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            GameManager.instance.isPlayerDead = true;
            AudioManager.Instance.PlayerDieAudio();
        }
    }
}
