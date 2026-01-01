using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<IDamagable>() != null)
        {
            collision.GetComponent<IDamagable>().TakeDamage(12);
            Destroy(gameObject);
        } 
        if(collision.tag == "Wall")
        {
            
            Destroy(gameObject);
        }
        
            
    }
}
