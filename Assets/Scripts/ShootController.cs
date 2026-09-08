using UnityEngine;
using UnityEngine.InputSystem;

public class ShootController : MonoBehaviour
{
    [SerializeField] private Transform bulletSpawn;
    [SerializeField] private GameObject ammo;

    private GameObject ammoInst;

    //mouses world position
    private Vector2 worldPosition;
    private Vector2 direction;

    private void Update()
    {
        Aim();
        Shoot();
    }

    private void Aim()
    {
        worldPosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        direction = (worldPosition - (Vector2)bulletSpawn.transform.position).normalized;
    }

    private void Shoot()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //spawn ammo
            ammoInst = Instantiate(ammo, bulletSpawn.position, Quaternion.identity);

            ammoInst.GetComponent<AmmoBehavior>().SetDirection(direction);
        }
    }

}

