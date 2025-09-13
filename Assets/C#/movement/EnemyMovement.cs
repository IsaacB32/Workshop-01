using System;
using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
   [SerializeField] private float movementSpeed = 5f;
   
   [SerializeField] private float distanceLeft = 5f;
   [SerializeField] private float distanceRight = 5f;

   private Vector2 leftBound;
   private Vector2 rightBound;
   private Vector2 startPosition;
   private float moveDirection = -1;

   private new EnemyAnimation animation;

   private bool canMove = true;

   private int health = 3;

   private void OnDrawGizmosSelected()
   {
      Gizmos.color = Color.red;
      Gizmos.DrawLine(transform.position, transform.position + (Vector3.left * distanceLeft));
      Gizmos.DrawLine(transform.position, transform.position + (Vector3.right * distanceRight));
   }

   private void Start()
   {
      leftBound = transform.position + (Vector3.left * distanceLeft);
      rightBound = transform.position + (Vector3.right * distanceRight);
      startPosition = transform.position;

      animation = GetComponent<EnemyAnimation>();
   }

   private void Update()
   {
      if (canMove) Move();
   }

   private void Move()
   {
      Vector2 move = transform.position;
      move.x += 0.01f * movementSpeed * moveDirection;
      transform.position = move;

      if (transform.position.x < leftBound.x || transform.position.x > rightBound.x) moveDirection *= -1;
      animation.Move(moveDirection);
   }

   private void OnTriggerEnter2D(Collider2D other)
   {
      if (other.tag == "Sword")
      {
         if (!canMove) return;
         if (--health <= 0) Death();
         else
         {
            StartCoroutine(HurtDelay());
         }
      }
   }

   IEnumerator HurtDelay()
   {
      animation.Hurt();
      canMove = false;
      yield return new WaitForSeconds(1f);
      canMove = true;
   }

   void Death()
   {
      animation.Death();
   }
}
