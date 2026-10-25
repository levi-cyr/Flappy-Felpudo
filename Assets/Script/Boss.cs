using TMPro;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int bossLife = 67; // vida do boss
    public int bossState = 0;
    Rigidbody2D bossRb;
    public Score scoreScript;
    public GameObject victoryText;

    void Start()
    {
        bossRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //BossAI();
    }

    void TakeDamage() // função de dano, tira 1 de vida do boss
    {
        bossLife--;
        if (bossLife <= 0) // caso a vida do boss for menor ou igual a 0 desativamos o gameObject dele
        {
            Die();
        }
    }

    void Die()
    {
        scoreScript.isBossDead = true; // chave de controle para não spawnar boss infinitamente
        victoryText.SetActive(true); // ativa o texto de vitoria
        gameObject.SetActive(false); //desativa o boss
    }

    void BossAI() // atualizar no futuro
    {
        switch (bossState)
        {
            case 1:
                Debug.Log("Fase 1 do Boss");
                break;
            case 2:
                Debug.Log("Fase 2 do boss");
                break;
            case 3:
                Debug.Log("Fase final do boss");
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(); // caso a vida dele nao seja menor ou igual a 0, ele só leva dano
            Destroy(collision.gameObject);
        }    
    }
}
