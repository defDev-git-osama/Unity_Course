using System;
using UnityEngine;




public enum MovementDirection { Up, Down, Right, Left };
public class PlayerMovementTopDown : MonoBehaviour
{
        [SerializeField] private float speed = 5f;
    [SerializeField] private Animator animator;

    public MovementDirection dir;

    private Rigidbody2D rb;
    private Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

      
        if (animator == null) animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        
        moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));

        bool moving = moveInput.sqrMagnitude > 0.001f;
        animator.SetBool("Moving", moving);

        if (moving)
        {
            
            if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
            {
                if (moveInput.x > 0)
                {
                    dir = MovementDirection.Right;
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else
                {
                    dir = MovementDirection.Left;
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }
            else
            {
                dir = (moveInput.y > 0) ? MovementDirection.Up : MovementDirection.Down;
            }
        }

        animator.SetInteger("Direction", (int)dir);
    }

    void FixedUpdate()
    {
        
        Vector2 v = moveInput.normalized * speed;
        rb.linearVelocity = v;

        
    }
}
