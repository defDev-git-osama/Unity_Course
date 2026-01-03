using Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour, IDamagable
{
    [Header("Health")]
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;

    [Header("Movement")]
    
    [SerializeField] private float animTime = 0.6f;
    [SerializeField] private float patrolSpeed = 2f;

    [Header("Detection")]
    [SerializeField] private float rayRange = 1f;
    [SerializeField] private LayerMask groundMask;

    [SerializeField] private Animator animator;

  
   

  
    private PlayerHealth playerHealth;
    private Rigidbody2D rb;
    private Vector2 velocity = Vector2.right;
    private bool canMove = true;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.freezeRotation = true;
        currentHealth = maxHealth;
    }

    private void Update()
    {
        animator.SetBool("CanMove", canMove);
        if (!canMove)  return;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, velocity, rayRange, groundMask);
        if (hit.collider != null)
        {
            velocity =  -1 *velocity ;
        }


        rb.linearVelocity = velocity * patrolSpeed;
        
        if (velocity.x < 0)
        {
            transform.localScale = new Vector3(-2f, 2f, 2f);
            
        }
        else
        {
            transform.localScale = new Vector3(2f, 2f, 2f);
        }
        
    }




    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHealth>() != null)
        {
            Debug.Log("Player detected!");
            playerHealth = collision.GetComponent<PlayerHealth>();
            StartCoroutine(Wait(animTime));
            animator.SetTrigger("Attack");
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.GetComponent<PlayerHealth>() != null)
        {
            playerHealth = null;
        }
    }


    private IEnumerator Wait( float time)
    {
        canMove = false;
        yield return new WaitForSeconds(time);
        canMove = true;
    }

    public void GiveDamage()
    {
        if (playerHealth == null) return;
        playerHealth.TakeDamage(30);
    }


    public void TakeDamage(int damage)
    {
        animator.SetTrigger("GetHit");
        StartCoroutine(Wait(animTime));
        currentHealth -= damage;
        Debug.Log("Enemy took " + damage + " damage and current health is " + currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("Enemy died!");
            Destroy(gameObject);
        }
    }
    

    

}