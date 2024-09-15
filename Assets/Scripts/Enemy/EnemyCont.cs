using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCont : MonoBehaviour
{
    public float moveSpeed = 3f;
    public Transform player;
    private Rigidbody2D rb;
    private bool isChasing = false;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
        }
        else
        {
            StopChasingPlayer();
        }
    }
    private void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = direction * moveSpeed;
    }
    private void StopChasingPlayer()
    {
        rb.velocity = Vector2.zero;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isChasing = false;
        }
    }
}