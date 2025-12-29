using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float jumpForce;




    private Rigidbody2D rb;

    //COORTINES
   
    void  Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    
    
    
    void Update()
    {
        rb.AddForce(GetMoveInput() * speed,ForceMode2D.Force);

        if(rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }


    private Vector2 GetMoveInput()
    {
        return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
