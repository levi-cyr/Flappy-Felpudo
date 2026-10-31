using System.Collections;
using UnityEngine;

public class BossShootWeapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public int minCooldownTime = 1;
    public int maxCooldownTime = 4;
    public bool isShooting = false;

    void Update()
    {
        if (!isShooting)
        {
            StartCoroutine(BulletShootTimer());
        }
    }
    public void Shoot()
    {
        if (isShooting)
        {
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            isShooting = false;
        }
    }

    public IEnumerator BulletShootTimer()
    {
        isShooting = true;
        int randomTimer = Random.Range(minCooldownTime, maxCooldownTime); // pega um tempo aleatorio entre 1 e 3 para atirar e não floodar tiro 
        Debug.Log("caiu o numero: " + randomTimer);

        yield return new WaitForSeconds(randomTimer);
        Shoot();

        isShooting = false;
    }
}
