
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovementScript : MonoBehaviour
{


    private Rigidbody2D rigidbody2D;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private bool isGrounded;

    [SerializeField]
    private float fallGravityMultiplier = 0.5f;

    [SerializeField]
    [Range(0f, 1f)]
    private float jumpCutMultiplier;

    [SerializeField]
    private float gravityScale = 1f;

    [SerializeField]
    private Transform rayCastSource;

    [SerializeField]
    private LayerMask layerMask;

    #region Coyote Time  
    [Header("Coyote Time")]
    [SerializeField]
    private float coyoteTime;

    [SerializeField]
    private float coyoteTimeCounter;



    #endregion

    #region Animation
    private SpriteRenderer spriteRenderer;
    private PlayerAnimation playerAnimation;
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        playerAnimation = GetComponent<PlayerAnimation>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        MovingFunction(horizontalInput);
        IsGroundedFunction();
        JumpFunction();
        AnimationPlayerFunction();
        SoundPlayFunction();

    }



    private void FixedUpdate()
    {


        PlayerMovementFunction();

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(rayCastSource.position, new Vector3(0.5f, 0.5f, 0));
    }

    void PlayerMovementFunction()
    {

        //OnJumpUpFunction();
        GravityScaleModifierFunction();

    }

    // basic jump function with coyote time 
    private void JumpFunction()
    {
        if (isGrounded)
        {
            coyoteTimeCounter = coyoteTime;
        }
        else
        {
            coyoteTimeCounter -= Time.deltaTime;
        }

        if (coyoteTimeCounter > 0f && Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump");

            rigidbody2D.AddForce(new Vector2(rigidbody2D.linearVelocity.x, jumpForce), ForceMode2D.Impulse);
        }
        if (Input.GetButtonUp("Jump") && rigidbody2D.linearVelocityY > 0)
        {
            rigidbody2D.linearVelocityY = rigidbody2D.linearVelocityY * jumpCutMultiplier;
            coyoteTimeCounter = 0f;
        }
    }
    // basic Moving Function 
    private void MovingFunction(float horizontalInput)
    {
        Vector2 movement = new Vector2(horizontalInput * speed, rigidbody2D.linearVelocity.y);
        if (horizontalInput < 0)
        {
            transform.rotation = new Quaternion(0, 1, 0, 0);
        }
        else if (horizontalInput > 0)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        rigidbody2D.linearVelocity = movement;

    }

    // Function to apply the jump cut 
    private void OnJumpUpFunction()
    {
        if (rigidbody2D.linearVelocityY > 0 && !isGrounded)
        {
            rigidbody2D.AddForce(Vector2.down * rigidbody2D.linearVelocityY * (1 - jumpCutMultiplier), ForceMode2D.Impulse);
        }

    }
    // Function thats add gravity effect when the player reach the max Height of the jump 
    private void GravityScaleModifierFunction()
    {
        if (rigidbody2D.linearVelocityY < 0)
        {
            rigidbody2D.gravityScale = gravityScale * fallGravityMultiplier;
        }
        else
        {
            rigidbody2D.gravityScale = gravityScale;
        }
    }

    // Function to check if the player is grounded 
    private void IsGroundedFunction()
    {
        //float raycastLength = 0.1f;
        //RaycastHit2D hit = Physics2D.Raycast(rayCastSource.position, Vector2.down, raycastLength);
        //if (rigidbody2D.linearVelocityY == 0 && hit.collider)
        //{
        //    Debug.DrawRay(rayCastSource.position, Vector2.down * raycastLength, Color.red);
        //    isGrounded = true;
        //}
        //else

        //    isGrounded = false;

        if (Physics2D.BoxCast(rayCastSource.position, new Vector2(0.5f, 0.5f), 0f, Vector2.down, 0.1f, layerMask))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }


    private void AnimationPlayerFunction()
    {

        if (isGrounded && rigidbody2D.linearVelocity.x != 0)
        {
            playerAnimation.PlayAnimation(Constants.PLAYER_RUN);
        }
        else if (isGrounded && rigidbody2D.linearVelocity.x == 0)
        {
            playerAnimation.PlayAnimation(Constants.PLAYER_IDLE);
        }

        if (!isGrounded && rigidbody2D.linearVelocityY > 0)
        {
            playerAnimation.PlayAnimation(Constants.PLAYER_JUMP);
        }
        else if (!isGrounded && rigidbody2D.linearVelocityY < 0)
        {
            playerAnimation.PlayAnimation(Constants.PLAYER_FALL);
        }
    }

    private void SoundPlayFunction()
    {
        if (Input.GetButtonDown("Jump"))
        {
            SfxManager.Instance.PlaySfx2D(Constants.JUMP_SFX);
        }
      

    }
}

