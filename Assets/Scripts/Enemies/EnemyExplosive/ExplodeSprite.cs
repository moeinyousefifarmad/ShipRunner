using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeSprite : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            GameManager.instance.isPlayerDead = true;
    }
}
