using System.Collections;
using UnityEngine;

public class CombatTopdown : MonoBehaviour
{
    [SerializeField] private int damage = 10;
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private PlayerMovementTopDown playerMovementTopDown;
    [SerializeField] private Animator animator;
    [SerializeField] private LayerMask enemyMask;


     [SerializeField]private int maxHealth = 100;
    private int currentHealth;
    private Vector2 raycastDirection = Vector2.down;

    void Start()
    {
        currentHealth = maxHealth;
    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Player took " + damage + " damage and current health is " + currentHealth);
        if (currentHealth <= 0)
        {
            Debug.Log("Player died!");
            Destroy(gameObject);
        }
    }
    void Update()
    {
        
        switch (playerMovementTopDown.dir)
        {
            case MovementDirection.Up:    raycastDirection = Vector2.up; break;
            case MovementDirection.Down:  raycastDirection = Vector2.down; break;
            case MovementDirection.Right: raycastDirection = Vector2.right; break;
            case MovementDirection.Left:  raycastDirection = Vector2.left; break;
        }

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");

            Vector2 origin = (Vector2)transform.position + raycastDirection * 0.2f; // small offset
            Debug.DrawRay(origin, raycastDirection * attackRange, Color.red, 0.2f);

            RaycastHit2D hit = Physics2D.Raycast(origin, raycastDirection, attackRange, enemyMask);
            if (hit.collider != null)
            {
                hit.collider.GetComponentInParent<IDamagable>()?.TakeDamage(damage);
            }
        }
    }


}
