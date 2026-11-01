using UnityEngine;

public class ShootWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource shootSoundEffect;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
            shootSoundEffect.Play();
        }
    }
    public void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
