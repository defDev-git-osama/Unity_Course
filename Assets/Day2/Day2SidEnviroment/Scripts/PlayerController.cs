using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float maxSpeed = 10f;   // (not used yet)
    [SerializeField] private float jumpForce = 7f;

    [Header("Animation")]
    [SerializeField] private Animator anim;

    [Header("Ground Check")]
    [SerializeField] private Vector3 offsetToGroundCheck = new Vector3(0f, -0.5f, 0f);
    [SerializeField] private float groundCheckRadius = 0.2f;
    [SerializeField] private LayerMask whatIsGround;


    
    private Rigidbody2D rb;
    private float moveDir;
    public bool IsDead;
    private static readonly int RunHash = Animator.StringToHash("Run");
    private static readonly int JumpHash = Animator.StringToHash("Jump");
    private static readonly int GroundedHash = Animator.StringToHash("Grounded");
    private static readonly int FallingHash = Animator.StringToHash("Falling");
    

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (IsDead) return;
        ApplyMovement();
        UpdateAnimation();

        if (Input.GetKeyDown(KeyCode.W) && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            anim.SetTrigger(JumpHash);
        }
    }
    private void ApplyMovement()
    {
        moveDir = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveDir * speed, rb.linearVelocity.y);
        
        if (moveDir > 0f) transform.localScale = new Vector3(1f, 1f, 1f);
        else if (moveDir < 0f) transform.localScale = new Vector3(-1f, 1f, 1f);


    }


    private void UpdateAnimation()
    {
        anim.SetBool(GroundedHash, IsGrounded());
        anim.SetBool(FallingHash, rb.linearVelocity.y < 0f);
        anim.SetBool(RunHash, moveDir != 0f);
    }
    private bool IsGrounded()
    {
        Vector2 checkPos = (Vector2)transform.position + (Vector2)offsetToGroundCheck;
        return Physics2D.OverlapCircle(checkPos, groundCheckRadius, whatIsGround);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector3 pos = transform.position + offsetToGroundCheck;
        Gizmos.DrawWireSphere(pos, groundCheckRadius);


        Gizmos.DrawRay(transform.position ,new Vector2(moveDir,0 ));
    }

}
