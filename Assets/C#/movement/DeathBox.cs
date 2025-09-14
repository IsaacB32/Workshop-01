using System;
using Unity.VisualScripting;
using UnityEngine;

public class DeathBox : MonoBehaviour
{
    [SerializeField] private GameObject respawnPoint;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.transform.position = respawnPoint.transform.position;
        }
    }
}
