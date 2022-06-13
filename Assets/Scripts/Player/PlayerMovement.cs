using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rb2d;
    public Animator animator;

    [Header("Move Left Right")]
    public float speed;
    public float HorizontalInput;
    public bool isFacingRight;

    [Header("Jump")]
    public float jumpVelocity;
    public float radiusToGround;
    public Transform groundCheckPoint;
    public LayerMask groundLayerMask;

    [Header("Double Jump")]
    public int totalJump;
    [SerializeField]
    private int jumpCount;
    public float offsetJump;

    [Header("Wall Slide")]
    public float radiusToWall;
    public LayerMask wallLayerMask;
    public float wallSlideSpeed;
    public bool isSlinding;

    public bool isDead;

    private void Start()
    {
        animator = GetComponent<Animator>();
        speed = 8f;
        isFacingRight = true;

        jumpVelocity = 15f;
        rb2d = GetComponent<Rigidbody2D>();
        rb2d.gravityScale = 4f;
        jumpCount = totalJump;

        radiusToGround = 0.32f;
        //offsetJump = 0.8f;
        isSlinding = false;
        isDead = false;
    }

    private void Update()
    {
        if (!isDead)
        {
            WallSlide();
            Jump();
            PlayerAnimator();
            IsTouchingWall();
        }
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            MoveLeftRight();
        }
    }

    private void MoveLeftRight()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");

        Flip();

        transform.position += new Vector3(HorizontalInput * Time.deltaTime * speed, 0f, 0f);
    }

    private void Flip()
    {
        if (HorizontalInput < 0 && isFacingRight || HorizontalInput > 0 && !isFacingRight)
        {
            isFacingRight = !isFacingRight;
            transform.Rotate(0f, 180f, 0f);
        }
    }

    private void Jump()
    {
        if (IsGrounded())
            jumpCount = totalJump;
        if (isSlinding)
            jumpCount = 1;

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && jumpCount != 0)
        {
            rb2d.velocity = Vector2.up * jumpVelocity;
            FindObjectOfType<SoundManager>().PlaySound("Jump");
            jumpCount--;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumpCount != 0 && !IsGrounded())
        {
            if (isSlinding)
            {
                rb2d.velocity = Vector2.up * jumpVelocity;
                //jumpCount--;
                jumpCount = 0;
            }
            else
            {
                rb2d.velocity = Vector2.up * jumpVelocity * offsetJump;
                //jumpCount--;
                jumpCount = 0;
            }
            FindObjectOfType<SoundManager>().PlaySound("Jump");
            animator.SetBool("PlayerJumpBonus", true);
        }
    }

    private void WallSlide()
    {
        if (IsTouchingWall() && !IsGrounded() && rb2d.velocity.y < 0 && HorizontalInput != 0)
        {
            Debug.Log("Player is slide");
            isSlinding = true;
        }
        else
        {
            isSlinding = false;
            Debug.Log("Player not slide");
        }

        if (isSlinding)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -wallSlideSpeed);
        }
    }

    private bool IsGrounded()
    {
        //Debug.Log("Ground: " + Physics2D.OverlapCircle(groundCheckPoint.position, radiusToGround, groundLayerMask));
        return Physics2D.OverlapCircle(groundCheckPoint.position, radiusToGround, groundLayerMask);
    }

    private bool IsTouchingWall()
    {
        return Physics2D.IsTouching(gameObject.GetComponent<Collider2D>(), GameObject.FindGameObjectWithTag("Wall").GetComponent<Collider2D>());
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(groundCheckPoint.position, radiusToGround);
    }

    private void PlayerAnimator()
    {
            //move left right
            if (HorizontalInput != 0)
                animator.SetBool("PlayerRun", true);
            else if (HorizontalInput == 0)
                animator.SetBool("PlayerRun", false);

            //jump, fall
            if (rb2d.velocity.y > 0)
            {
                animator.SetBool("PlayerJump", true);
            }
            if (rb2d.velocity.y < 0)
            {
                animator.SetBool("PlayerJump", false);
                animator.SetBool("PlayerFall", true);
                animator.SetBool("PlayerJumpBonus", false);
            }
            if (rb2d.velocity.y == 0)
            {
                animator.SetBool("PlayerJump", false);
                animator.SetBool("PlayerFall", false);
            }

            //sliding
            if (isSlinding == true)
            {
                animator.SetBool("PlayerWallSlide", true);

            }
            else
            {
                animator.SetBool("PlayerWallSlide", false);
            }


    }
}
