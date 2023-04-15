using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    public float MoveSpeed;
    public float JumpForce;
    public PauseMenu pauseMenu;

    private bool isGrounded;

    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask collisionLayer;

    public Rigidbody2D rb;
    public CapsuleCollider2D playerCollider;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    private Vector3 velocity = Vector3.zero;
    public static PlayerMovement instance;

    private float horizontalMovement;

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
        MovePlayer(horizontalMovement);

        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        animator.SetFloat("Speed", characterVelocity);
    }
    void MovePlayer(float _horizontalMovement)
    {
        Vector3 targetVelocity = new Vector3(_horizontalMovement, rb.velocity.y, 0);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
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

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        horizontalMovement = movementVector.x * MoveSpeed;
    }

    void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector2(0f, JumpForce));
        }
    }

    void OnPause()
    {
        pauseMenu.OnPause();
    }


    void OnInteract()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * (GetComponent<CapsuleCollider2D>().size.x / 2), 1f, LayerMask.GetMask("Interactables"));

        if (hit.collider == null || (hit.collider.tag != "chest" && hit.collider.tag != "pnj" && hit.collider.tag != "item"))
        {
            hit = Physics2D.Raycast(transform.position, Vector2.left * (GetComponent<CapsuleCollider2D>().size.x / 2), 1f, LayerMask.GetMask("Interactables"));
        }
        if (hit.collider != null && hit.collider.tag == "chest")
        {
            hit.collider.GetComponent<Chest>().OnInteract();
        }
        else if (hit.collider != null && hit.collider.tag == "pnj")
        {
            hit.collider.GetComponent<dialogueTrigger>().OnInteract();
        }else if (hit.collider != null && hit.collider.tag == "item")
        {
            hit.collider.GetComponent<PickUpItem>().OnInteract();
    }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
