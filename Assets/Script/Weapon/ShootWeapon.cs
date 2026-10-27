using UnityEngine;

public class ShootWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
