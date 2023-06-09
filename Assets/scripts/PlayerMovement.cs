/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    private float DirtX = 0f;
    [SerializeField] private float MoveSpeed = 7f;
    [SerializeField] private float JumpForce = 14f;
    public Joystick joystick;
    private bool isJumping = false;
    private float jumpThreshold = 0.8f; // Adjust this value to set the jump threshold

    private enum MovementPhase { idle, running, jumping, falling }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Check for joystick input
        Vector2 joystickInput = new Vector2(joystick.Horizontal, joystick.Vertical).normalized;
        DirtX = joystickInput.x;

        rb.velocity = new Vector2(DirtX * MoveSpeed, rb.velocity.y);

        if (joystickInput.y > jumpThreshold && IsGrounded() && !isJumping)
        {
            rb.velocity = new Vector2(DirtX * MoveSpeed, JumpForce);
            isJumping = true;
        }

        UpdateAnimationPhase();
    }

    private void UpdateAnimationPhase()
    {
        MovementPhase phase;
        if (DirtX > 0f)
        {
            phase = MovementPhase.running;
            sprite.flipX = false;
        }
        else if (DirtX < 0f)
        {
            phase = MovementPhase.running;
            sprite.flipX = true;
        }
        else
        {
            phase = MovementPhase.idle;
        }

        if (rb.velocity.y > .1f)
        {
            phase = MovementPhase.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            phase = MovementPhase.falling;
        }

        anim.SetInteger("Phase", (int)phase);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
           isJumping = false;
        }
    }
}*/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    private float DirtX = 0f;
    [SerializeField] private float MoveSpeed = 7f;
    [SerializeField] private float JumpForce = 14f;
    public Joystick joystick;
    private bool isJumping = false;
    private float jumpThreshold = 0.8f; // Adjust this value to set the jump threshold

    private enum MovementPhase { idle, running, jumping, falling }

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        // Check for joystick input
        Vector2 joystickInput = new Vector2(joystick.Horizontal, joystick.Vertical).normalized;
        DirtX = joystickInput.x;

        // Check for keyboard input
        DirtX += Input.GetAxis("Horizontal");

        rb.velocity = new Vector2(DirtX * MoveSpeed, rb.velocity.y);

        if (joystickInput.y > jumpThreshold && IsGrounded() && !isJumping)
        {
            rb.velocity = new Vector2(DirtX * MoveSpeed, JumpForce);
            isJumping = true;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && IsGrounded() && !isJumping)
        {
            rb.velocity = new Vector2(DirtX * MoveSpeed, JumpForce);
            isJumping = true;
        }

        UpdateAnimationPhase();
    }

    private void UpdateAnimationPhase()
    {
        MovementPhase phase;
        if (DirtX > 0f)
        {
            phase = MovementPhase.running;
            sprite.flipX = false;
        }
        else if (DirtX < 0f)
        {
            phase = MovementPhase.running;
            sprite.flipX = true;
        }
        else
        {
            phase = MovementPhase.idle;
        }

        if (rb.velocity.y > .1f)
        {
            phase = MovementPhase.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            phase = MovementPhase.falling;
        }

        anim.SetInteger("Phase", (int)phase);
    }

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isJumping = false;
        }
    }
}
