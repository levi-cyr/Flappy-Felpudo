using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D bulletRb;
    public float destroyLimitX = 10f;
    void Start()
    {
        bulletRb.linearVelocity = transform.right * speed;
    }

    void Update()
    {
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if (gameObject.transform.position.x > destroyLimitX)
        {
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Enemy"))
        {
            Enemy enemyScript = hit.GetComponent<Enemy>();

            if (enemyScript != null)
            {
                enemyScript.Die(); // chama a função de morte do inimigo no script do enemy
            }
            Destroy(gameObject); // destroi a bala
        }
    }
}
