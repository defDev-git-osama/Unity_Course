using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private  int maxHealth;
    private  int currentHealth;
    private PlayerController playerController;
    private void Start()
    {
        playerController = GetComponent<PlayerController>();
        currentHealth = maxHealth;
    }

    
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            playerController.IsDead = true;
        }
    }

}