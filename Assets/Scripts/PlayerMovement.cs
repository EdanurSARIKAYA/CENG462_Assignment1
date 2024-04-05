using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Oyuncunun hareket hızı

    private Rigidbody2D body;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private bool grounded;
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float moveInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(moveInput * moveSpeed, body.velocity.y);

        if (moveInput > 0) // Sağa gidiyorsa
        {
            spriteRenderer.flipX = false; // Sağa dönük olacak şekilde ayarla
        }
        else if (moveInput < 0) // Sola gidiyorsa
        {
            spriteRenderer.flipX = true; // Sola dönük olacak şekilde ayarla
        }

        if (Input.GetKeyDown(KeyCode.Space)  && grounded)
            Jump();
        animator.SetBool("run", moveInput != 0);
        animator.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, moveSpeed);
        animator.SetTrigger("jump");
        grounded = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}
