
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class PlayerMovementScript : MonoBehaviour
{


    private Rigidbody2D rigidbody2D;
    [SerializeField ]
    private float speed;
    [SerializeField]
    private float jumpForce;
    [SerializeField]
    private bool isGrounded;

    [SerializeField]
    private Transform rayCastSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        speed = 5;
    }

    // Update is called once per frame
    void Update()
    {


    }



    private void FixedUpdate()
    {

        IsGroundedFunction();
        PlayerMovementFunction();
       
    }

    void PlayerMovementFunction()
    {
        
        float horizontalInput = Input.GetAxis("Horizontal");

       
        if (Input.GetButton("Jump") && isGrounded)
        {
            Debug.Log("Is Clicked");
            rigidbody2D.AddForce(new Vector2(rigidbody2D.linearVelocity.x, jumpForce) , ForceMode2D.Impulse);
        }

      
        Vector2 movement = new Vector2(horizontalInput * speed, rigidbody2D.linearVelocity.y);
        if (horizontalInput < 0)
        {
            transform.rotation =new Quaternion(0,1,0,0);
        }
        else if (horizontalInput > 0) 
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        rigidbody2D.linearVelocity = movement;

        
        // rigidbody2D.AddForce(new Vector2(horizontalInput * speed, 0), ForceMode2D.Force);

       
        Debug.Log("Horizontal Input: " + horizontalInput);
    }
    private void IsGroundedFunction()
    {
        float raycastLength = 0.1f;
        RaycastHit2D hit = Physics2D.Raycast(rayCastSource.position, Vector2.down, raycastLength);

        if (hit.collider)
        {

            Debug.DrawRay(rayCastSource.position, Vector2.down * raycastLength, Color.red);
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }

}
