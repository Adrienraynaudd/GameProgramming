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
    public Animator animator2;
    public SpriteRenderer spriteRenderer;
    private Vector3 velocity = Vector3.zero;
    public Transform playerMov;
    public PlayerInput player1;
    public PlayerInput player2;
    public static PlayerMovement instance;

    private float horizontalMovement;

    private void Awake()
    {
        instance = this;
    }
    // Update is called once per frame

void Start()
{
   
}
    void Update() 
    {
        InputDevice targetDevice = player1.devices[0];
        InputDevice targetDevice2 = player2.devices[0];
        player1.SwitchCurrentControlScheme(targetDevice);
        player2.SwitchCurrentControlScheme(targetDevice2);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, collisionLayer); // this is called for check if the player is grounded
        MovePlayer(horizontalMovement);

        Flip(rb.velocity.x);
        float characterVelocity = Mathf.Abs(rb.velocity.x);
        if (animator.gameObject.activeSelf){
        animator.SetFloat("Speed", characterVelocity);
        }
        animator2.SetFloat("Speed", characterVelocity);
        Vector3 dir = playerMov.position - transform.position;
        if (dir.x > 19){
            playerMov.position = new Vector3(transform.position.x , transform.position.y, 0);
        }else if (dir.x < -19){
            playerMov.position = new Vector3(transform.position.x , transform.position.y, 0);
        }
         
    }
    void MovePlayer(float _horizontalMovement) // this is called for move the player
    {
        Vector3 targetVelocity = new Vector3(_horizontalMovement, rb.velocity.y, 0);
        rb.velocity = Vector3.SmoothDamp(rb.velocity, targetVelocity, ref velocity, .05f);
    }
    void Flip(float _velocity) //this is called for flip the sprite of the player
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

    void OnMove(InputValue movementValue) // this is called for move the player
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        horizontalMovement = movementVector.x * MoveSpeed;
    }

    void OnJump() // this is called for jump the player
    {
        if (isGrounded && Time.timeScale != 0)
        {
            rb.AddForce(new Vector2(0f, JumpForce));
        }
    }

    void OnPause()
    {
        if(PlayerHealth.instance.currentHealth > 0){
            pauseMenu.OnPause();
        }
    }


    void OnInteract() // this is called for interact with the pnj, chest, item and shop
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right * (GetComponent<CapsuleCollider2D>().size.x / 2), 1f, LayerMask.GetMask("Interactables"));

        if (hit.collider == null || (hit.collider.tag != "chest" && hit.collider.tag != "pnj" && hit.collider.tag != "item" && hit.collider.tag != "shop"))
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
        }else if (hit.collider != null && hit.collider.tag == "shop")
        {
            hit.collider.GetComponent<ShopTrigger>().OnInteract();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}
