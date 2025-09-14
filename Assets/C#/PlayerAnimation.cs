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
       //animation
    }

    public void Attack()
    {
        //animation
    }
    
}
