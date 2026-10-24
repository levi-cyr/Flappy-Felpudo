using UnityEngine;

public class Enemy : MonoBehaviour
{
    public void Die () // quando o inimigo | boss morrer
    {
        Destroy(gameObject);
        Debug.Log(gameObject.name + "morreu");
    }
    void TakeDamage() // para o boss
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerController playerGameObj = collision.GetComponent<PlayerController>();

        if (collision.CompareTag("Player"))
        {
            playerGameObj.PlayerDeath();
        }
    }
}
