using UnityEngine;

public class ShootWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public AudioSource shootSoundEffect;
    public PlayerController playerControllerScript;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && playerControllerScript.canMove)
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
