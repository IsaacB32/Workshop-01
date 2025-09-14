using System;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }
    
    public void Hurt()
    {
        //animation
    }

    public void Death()
    {
        //animation 
    }

    public void TurnOff()
    {
        anim.enabled = false;
    }
}
