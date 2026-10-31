using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Die() // quando o inimigo
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerGameObj = collision.GetComponent<PlayerController>();

        if (collision.CompareTag("Player"))
        {
            playerGameObj.TakeDamage(1); // dano no player
            Die();
        }
    }
}
