using UnityEngine;

public class AmmoBehavior : MonoBehaviour
{
    [SerializeField] private float normalAmmoSpeed = 15f;
    [SerializeField] private float destroyTime = 4f;
    [SerializeField] private LayerMask whatDestroysAmmo;


    private Rigidbody2D rb;
    private Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        SetDestroyTime();
        SetStraightVelocity();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //is the collision within the whatDestroysAmmo layerMask
        if((whatDestroysAmmo.value & (1 << collision.gameObject.layer)) > 0)
        {
            //TODO: add:
            //spawn particles
            //sound effects
            //ScreenShake
            //Damage Enemy
            //Destroy the Ammo
            Destroy(gameObject);
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
