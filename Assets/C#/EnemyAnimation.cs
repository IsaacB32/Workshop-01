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
        anim.Play("EnemyHit");
    }

    public void Death()
    {
        anim.Play("EnemyDie");
    }

    public void TurnOff()
    {
        anim.enabled = false;
    }
}
