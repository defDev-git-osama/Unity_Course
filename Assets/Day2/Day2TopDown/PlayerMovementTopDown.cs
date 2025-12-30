using System;
using UnityEngine;




public enum MovementDirection { Up, Down, Right, Left };
public class PlayerMovementTopDown : MonoBehaviour
{
   [SerializeField] private float speed = 5f;
   [SerializeField] private Animator animator;

   [SerializeField] private MovementDirection dir;

   
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger("Attack");
        }
        

        if(GetMoveInput() != Vector3.zero)
        {
            animator.SetBool("Moving", true);
        }
        else
        {
            animator.SetBool("Moving", false);
        }

        if(Input.GetKey("w"))
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
            dir = MovementDirection.Up;
        }
        if (Input.GetKey("s"))
        {
            transform.position += Vector3.down * speed * Time.deltaTime;
            dir = MovementDirection.Down;
        }
        if (Input.GetKey("d"))
        {
            transform.position += Vector3.right * speed * Time.deltaTime;
            dir = MovementDirection.Right  ;
            transform.localScale = new Vector3(1, 1, 1);
            
        }
        if (Input.GetKey("a"))
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
            dir = MovementDirection.Left;
            transform.localScale = new Vector3(-1, 1, 1);
        }
      
        animator.SetInteger("Direction", (int)dir);
    }



    private Vector3 GetMoveInput()
    {
        return new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"),0);
    }
}
