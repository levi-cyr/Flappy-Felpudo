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
}
