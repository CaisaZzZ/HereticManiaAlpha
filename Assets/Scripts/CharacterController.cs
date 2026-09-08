using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D mainBody;
    public InputAction moveControls;
    public InputAction jumpControls;
    public SpriteRenderer faceDirection;

    public float moveDirection;
    private bool isGrounded;
    public float speed;
    public float jumpForce;

    public int targetFrameRate = 60;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Application.targetFrameRate = targetFrameRate;
        moveDirection = moveControls.ReadValue<Vector2>().x;

        //turns sprite on it's x-axis
        if(moveDirection < 0)
        {
            faceDirection.flipX = true;
        }
        else if(moveDirection > 0)
        {
            faceDirection.flipX = false;
        }

        //jump mechanic
        if (jumpControls.WasPressedThisFrame() && isGrounded)
        {
            mainBody.linearVelocity = new Vector2(mainBody.linearVelocity.x, jumpForce);
        }

    }

    void FixedUpdate()
    {
        mainBody.linearVelocity = new Vector2(moveDirection * speed, mainBody.linearVelocity.y);
    }

    void OnEnable()
    {
        moveControls.Enable();
        jumpControls.Enable();

    }

    void OnDisable()
    {
        moveControls.Disable();
        jumpControls.Disable();
    }


    //jump mech stuff
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
