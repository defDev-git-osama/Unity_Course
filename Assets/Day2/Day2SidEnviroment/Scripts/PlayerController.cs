using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;

    [SerializeField] private Animator anim;

    private Rigidbody2D rb;




  

   
    void  Start()
    {
      rb = GetComponent<Rigidbody2D>();
    }
    
    
    
    void Update()
    {
      transform.position += new Vector3(GetMoveInput(), 0, 0) * speed * Time.deltaTime;
        if (GetMoveInput() > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (GetMoveInput() < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if(GetMoveInput() != 0)
        {
            anim.SetBool("Run", true);
        }

        if(GetMoveInput() == 0)
        {
            anim.SetBool("Run", false);
        }
    
   



        if(Input.GetMouseButtonDown(0))
        {
            anim.SetTrigger("Attack");
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
          anim.SetTrigger("Jump");
        }

    }


    private float GetMoveInput()
    {
        return Input.GetAxis("Horizontal");
    }
}
