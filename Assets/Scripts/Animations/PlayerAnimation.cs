using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponentInParent<SpriteRenderer>();
    }
    public void SetFalseIsGravityChange()
    {
        animator.SetBool("isGravityChange" , false);

       // if(spriteRenderer.flipX == true)
        //    spriteRenderer.flipX = false;
       // else
          //  spriteRenderer.flipX = true;
    }
}
