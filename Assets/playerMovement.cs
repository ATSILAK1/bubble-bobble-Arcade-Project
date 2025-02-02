
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{


    private Rigidbody2D rigidbody2D;
    private float speed;
    [SerializeField]
    private float jumpForce; 
    [SerializeField]
    private bool isGrounded ;
    
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


        PlayerMovementFunction();
        IsGroundedFunction();
    }

    void PlayerMovementFunction()
    {
        if(Input.GetButton("Jump") && isGrounded )
        {
            rigidbody2D.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        Debug.Log(Input.GetAxis("Horizontal"));

        if (Input.GetAxis("Horizontal") > 0)

            rigidbody2D.AddForce(Input.GetAxis("Horizontal") * Vector2.right * speed, ForceMode2D.Force);
            //rigidbody2D.linearVelocity = Input.GetAxis("Horizontal") * Vector2.right * speed;
        else if (Input.GetAxis("Horizontal") < 0)

            rigidbody2D.AddForce(Input.GetAxis("Horizontal") * -Vector2.left * speed, ForceMode2D.Force);
            //rigidbody2D.linearVelocity = Input.GetAxis("Horizontal") * Vector2.right * speed;
        else

            rigidbody2D.linearVelocity = Vector2.zero;
    }

    private void IsGroundedFunction()
    {
        float raycastLength = 0.1f; 
        RaycastHit2D hit = Physics2D.Raycast(rayCastSource.position, -Vector2.up, raycastLength);

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
