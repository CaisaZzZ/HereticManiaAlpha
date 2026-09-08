using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterController : MonoBehaviour
{
    public Rigidbody2D mainBody;
    public InputAction playerControls;
    public float moveDirection;
    public float speed;

    public SpriteRenderer faceDirection;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        moveDirection = playerControls.ReadValue<Vector2>().x;

        //turns sprite on it's x-axis
        if(moveDirection < 0)
        {
            faceDirection.flipX = true;
        }
        else if(moveDirection > 0)
        {
            faceDirection.flipX = false;
        }
    }

    void FixedUpdate()
    {
        mainBody.linearVelocity = new Vector2(moveDirection * speed, mainBody.linearVelocity.y);
    }

    void OnEnable()
    {
        playerControls.Enable();
    }

    void OnDisable()
    {
        playerControls.Disable();
    }
}
