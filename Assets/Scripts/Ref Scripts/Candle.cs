using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class Candle : MonoBehaviour
{
    Vector2 moveInput;
    Rigidbody2D candlerb;
    Animator candleanimator;
    CapsuleCollider2D candlecollider;
    [SerializeField] float moveSpeed = 10f;
    [SerializeField] float jumpForce = 10f;
    [SerializeField] float dashForce = 10f;
    [SerializeField] float climbSpeed = 10f;
    [SerializeField] float normalGravity = 9.8f;

    void Start()
    {
        candlerb = GetComponent<Rigidbody2D>();
        candleanimator = GetComponent<Animator>();
        candlecollider = GetComponent<CapsuleCollider2D>();
        normalGravity = candlerb.gravityScale;

    }


    void Update()
    {
        Walk();
        WalkL();
        OnClimb();
        FlipSprite();
    }

    void OnJump(InputValue spcBar)
    {
        if (spcBar.isPressed && candlecollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            candlerb.linearVelocity = new Vector2(candlerb.linearVelocity.x, jumpForce);
            candleanimator.SetTrigger("isJumping");
        }
    }

    void OnDash(InputValue shift)
    {
        if (shift.isPressed)
        {
            candlerb.linearVelocity = new Vector2(dashForce, candlerb.linearVelocity.y);
            candleanimator.SetTrigger("isDashing");
        }
    }

    void OnClimb()
    {
        if (!candlecollider.IsTouchingLayers(LayerMask.GetMask("Climbable")))
        {
            candlerb.gravityScale = normalGravity;
            return;
        }

        candlerb.gravityScale = 0f;
        Vector2 climbVelocity = new Vector2(candlerb.linearVelocity.x, moveInput.y * climbSpeed);
        candlerb.linearVelocity = climbVelocity;


    }


    private void Walk()
    {
        Vector2 walkVelocity = new Vector2(moveInput.x * moveSpeed, candlerb.linearVelocity.y);
        candlerb.linearVelocity = walkVelocity;
        bool isMovingR = (candlerb.linearVelocity.x) > 0;
        candleanimator.SetBool("isWalking", isMovingR);
    }

    private void WalkL()
    {
        Vector2 walkVelocity = new Vector2(moveInput.x * moveSpeed, candlerb.linearVelocity.y);
        candlerb.linearVelocity = walkVelocity;
        bool isMovingL = (candlerb.linearVelocity.x) < 0;
        candleanimator.SetBool("isWalkingL", isMovingL);
    }


    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void FlipSprite()
    {
        bool isMovingL = (candlerb.linearVelocity.x) > Mathf.Epsilon;
        if (isMovingL)
        {
            transform.localScale = new Vector2(Mathf.Sign(candlerb.linearVelocity.x), 1f);
        }
    }
}

