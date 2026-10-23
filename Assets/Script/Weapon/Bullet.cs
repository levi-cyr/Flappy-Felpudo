using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D bulletRb;
    Enemy enemyScript;
    void Start()
    {
        bulletRb.linearVelocity = transform.right * speed;
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
