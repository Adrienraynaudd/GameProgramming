using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveSpeed;
    public float JumpForce;

    private bool isGrounded;
    private bool isJumping = false;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayer;

    public Rigidbody2D rb;
    public CapsuleCollider2D playerCollider;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private Vector3 velocity = Vector3.zero;
    public static PlayerMovement instance;

   private void Awake()
   {
       if (instance != null)
       {
           Debug.LogWarning("More than one instance of PlayerMouvement found!");
           return;
       }
       instance = this;
   }
    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer);
        float horizontalMovement = Input.GetAxis("Horizontal") * MoveSpeed*Time.fixedDeltaTime;

        if (Input.GetButtonDown("Jump")&& isGrounded)
        {
           isJumping = true;
        }
        MovePlayer(horizontalMovement);
        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector2(_horizontalMovement, rb.velocity.y);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
        if (isJumping == true)
        {
            rb.AddForce(new Vector2(0f,JumpForce));
            isJumping = false;
        }
    }
    void Flip(float _velocity)
    {
        if (_velocity > 0.1f)
        {
            spriteRenderer.flipX = false;
        }
        else if (_velocity < -0.1f)
        {
            spriteRenderer.flipX = true;
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
