using UnityEngine;

public class Player2Movement : MonoBehaviour
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
        float moveInput = 0f;

        // Sağa gitme
        if (Input.GetKey(KeyCode.RightArrow))
        {
            moveInput = 1f;
            spriteRenderer.flipX = false; // Sağa dönük olacak şekilde ayarla
        }
        // Sola gitme
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            moveInput = -1f;
            spriteRenderer.flipX = true; // Sola dönük olacak şekilde ayarla
        }

        body.velocity = new Vector2(moveInput * moveSpeed, body.velocity.y);

        // Zıplama
        if (Input.GetKeyDown(KeyCode.UpArrow) && grounded) // Sadece yerdeyken zıplama izni ver
        {
            Jump();
        }

        //Set animator parameters
        animator.SetBool("walk", moveInput != 0);
        animator.SetBool("grounded", grounded);
    }

    private void Jump()
    {
        body.velocity = new Vector2(body.velocity.x, moveSpeed);
        animator.SetTrigger("jump");
        grounded = false; // Zıplama yapıldığında yerde değiliz
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true; // Yere temas ettiğimizde grounded'ı true yap
        }
    }
}
