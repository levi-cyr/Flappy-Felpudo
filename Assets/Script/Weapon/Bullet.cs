using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D bulletRb;
    public float destroyLimitX = 10f;
    bool isExploding = false;
    Score scoreScript;
    Animator bulletAnim;

    void Start()
    {
        scoreScript = FindFirstObjectByType<Score>();
        bulletAnim = GetComponent<Animator>();
        bulletRb.linearVelocity = transform.right * speed;
    }

    void Update()
    {
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if (isExploding) 
        {
            return;
        }

        if (gameObject.transform.position.x > destroyLimitX)
        {
            Destroy(gameObject);
        }
    }

    void ExplodeAndDestroy() 
    {
        if (isExploding) 
        {
            return;
        }
        isExploding = true;
        bulletAnim.SetTrigger("explode");
        bulletRb.linearVelocity = Vector2.zero;

        Destroy(gameObject, 0.3f);
    }


    void OnTriggerEnter2D(Collider2D hit)
    {
        if (isExploding) 
        {
            return;
        }
        if (hit.CompareTag("Enemy"))
        {
            Enemy enemyScript = hit.GetComponent<Enemy>();

            if (enemyScript != null)
            {
                enemyScript.Die(); // chama a função de morte do inimigo no script do enemy
            }

            if (scoreScript != null)
            {
                scoreScript.enemiesKilled++;
            }
            ExplodeAndDestroy();
        }
        if (hit.CompareTag("Boss"))
        {
            ExplodeAndDestroy();
        }
        if (hit.CompareTag("Limit")) 
        {
            ExplodeAndDestroy();
        }
    }
}
