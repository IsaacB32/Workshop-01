using System;
using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Move(bool isMoving)
    {
       anim.SetBool("walking", isMoving);
    }

    public void Attack()
    {
        anim.Play("PlayerAttack");
    }
    
}
