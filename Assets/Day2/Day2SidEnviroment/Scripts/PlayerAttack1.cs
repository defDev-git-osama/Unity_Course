using System;
using UnityEngine;

public class PlayerAttack1 : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] private Rigidbody2D projectile;
    [SerializeField] private Animator anim;

    [SerializeField] private float projectileForce = 2f;
    [SerializeField] private float attackRate = 2f;
    private float nextAttackTime = 0f;

    void Update()
    {
        nextAttackTime += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && nextAttackTime >= attackRate)
        {
            Vector2 dir;
            anim.SetTrigger("Attack");
           Rigidbody2D projectileInstance =  Instantiate(projectile, attackPoint.position, transform.rotation);
           if(transform.localScale.x < 0f)
           {
               projectileInstance.transform.localScale = new Vector3(-1f, 1f, 1f);
               dir = Vector2.left;
           }
           else
           {
               projectileInstance.transform.localScale = new Vector3(1f, 1f, 1f);
               dir = Vector2.right;
           }

           projectileInstance.AddForce(dir * projectileForce, ForceMode2D.Impulse); 
            nextAttackTime = 0f;
        }
      
        

    }


}
