using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 15f;
    [SerializeField] private float jumpHeight = 5f;
    private Vector2 moveDir;
    private Rigidbody2D myRB;
    private new PlayerAnimation animation;

    private bool onGround;
    private bool jump = false;
    
    public GameObject rayStart;
    public LayerMask groundLayer;

    private bool movingLeft;
    private bool movingRight;

    [SerializeField] private BoxCollider2D sword;
    
    
    private void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        animation.GetComponent<PlayerAnimation>();
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(rayStart.transform.position, Vector2.down, .5f, groundLayer.value);
        onGround = hit;
    }

    private void FixedUpdate()
    {
        myRB.linearVelocityX = moveDir.x;
        if (jump)
        {
            myRB.AddForceY(jumpHeight);
            jump = false;
        }
    }

    public void Move(InputAction.CallbackContext context)
    {
        moveDir.x = context.ReadValue<Vector2>().x * movementSpeed;
        Vector2 temp = transform.localScale;
        if (!context.canceled) temp.x = Mathf.Clamp(moveDir.x, -1f, 1f); 
        transform.localScale = temp;
        animation.Move(moveDir.x);
    }
    
    public void Jump(InputAction.CallbackContext context)
    {
        if (onGround && context.started)
        {
            jump = true;
            animation.Jump(onGround);
        }
    }

    public void Attack(InputAction.CallbackContext context)
    {
        if (context.started) StartCoroutine(AttackDelay());
    }

    private IEnumerator AttackDelay()
    {
        animation.Attack();
        sword.enabled = true;
        yield return new WaitForSeconds(0.15f);
        sword.enabled = false;
    }
}
