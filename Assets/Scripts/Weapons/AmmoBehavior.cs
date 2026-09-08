using UnityEngine;

public class AmmoBehavior : MonoBehaviour
{
    [SerializeField] private float normalAmmoSpeed = 15f;
    [SerializeField] private float destroyTime;
    [SerializeField] private float rotation;

    private Rigidbody2D rb;
    private Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SetDestroyTime();
        SetStraightVelocity();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            Destroy(gameObject);
        }

        if(collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
        {
            //bounce upward
            Vector2 bounceDirection = collision.GetContact(0).normal;

            bounceDirection.y += 0.1f;
            bounceDirection.Normalize();

            rb.linearVelocity = bounceDirection * 1f;

            //spin
            rb.angularVelocity = rotation;
        }
    }

    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection;
    }
    private void SetStraightVelocity()
    {
        rb.linearVelocity = direction * normalAmmoSpeed;
    }

    private void SetDestroyTime()
    {
        //gets rid of spawned bullets
        Destroy(gameObject, destroyTime);
    }
}
