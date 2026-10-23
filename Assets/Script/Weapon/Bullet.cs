using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D bulletRb;
    void Start()
    {
        bulletRb.linearVelocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hit)
    {
        if (hit.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }
    }
}
