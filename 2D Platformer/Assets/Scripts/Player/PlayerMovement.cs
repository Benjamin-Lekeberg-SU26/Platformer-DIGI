using NUnit.Framework;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerMovement : MonoBehaviour
{
    bool isGrounded;
    [SerializeField] float moveSpeed = 4f;
    [SerializeField] float jumpForce = 7f;
    [SerializeField] float doubleJumpForce = 5f;
    Rigidbody2D rb;
    Vector2 moveInput;
    [SerializeField] ContactFilter2D groundFilter;
    float currentYVelocity;
    bool canDoubleJump = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump()
    {
        Jump();
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        currentYVelocity = rb.linearVelocity.y;
    }

    void FixedUpdate()
    {
        isGrounded = rb.IsTouching(groundFilter);
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveInput.x * moveSpeed, rb.linearVelocity.y);
    }

    void Jump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            canDoubleJump = true;
        }
        else if (canDoubleJump)
        {
            DoubleJump();
        }
    }

    void DoubleJump()
    {
        if (currentYVelocity < 0) // If the player is falling, apply a stronger force to counteract the downward velocity
        {
            rb.AddForce(Vector2.up * (doubleJumpForce - currentYVelocity), ForceMode2D.Impulse);
            canDoubleJump = false;
        }
        else
        {
            rb.AddForce(Vector2.up * doubleJumpForce, ForceMode2D.Impulse);
            canDoubleJump = false;
        }
    }
}
