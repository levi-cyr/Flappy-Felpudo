using TMPro;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public GameObject victoryText;

    [Header("Boss Control")]
    public int bossLife = 50; // vida do boss
    public int bossState = 0; // estado do boss / fase que ele está

    [Header("Scripts")]
    public Score scoreScript;
    public Timer timerScript;
    public BossShootWeapon bossShootWeaponScript;
    public WinGameCutscene winGameCutsceneScript;
    Animator boosAnim;


    void Start()
    {
        boosAnim = GetComponent<Animator>();
    }

    void Update()
    {
        BossAI();
    }

    void TakeDamage() // função de dano, tira 1 de vida do boss
    {
        bossLife--;
        if (bossLife <= 0) // caso a vida do boss for menor ou igual a 0 desativamos o gameObject dele
        {
            Die();
            timerScript.stopTime = true; // para o tempo
            winGameCutsceneScript.endGame = true; // ativa a chave que verifica se o jogo acabou
        }
    }

    void Die()
    {
        scoreScript.isBossDead = true; // chave de controle para não spawnar boss infinitamente
        victoryText.SetActive(true); // ativa o texto de vitoria
        gameObject.SetActive(false); //desativa o boss
        scoreScript.enemiesKilled = scoreScript.enemiesKilled + 6200; // pontuação a mais que o boss da
    }

    void BossAI() // atualizar no futuro | 27/10/2026 implementando algumas coisas
    {
        if (bossState == 0 && bossLife == 1)
        {
            ChangePhase(1); // vai para a primeira fase do boss. Removi do switch case pq ele tava chamando toda hora o script no update, entao assim fica melhor
        }
    }

    void ChangePhase(int newPhase)
    {
        bossState = newPhase;
        if (bossState == 1)
        {
            Debug.Log("Fase 1 do Boss");
            bossLife = 100;

            boosAnim.SetBool("1stDefeat", true);
            bossShootWeaponScript.minCooldownTime = 1;
            bossShootWeaponScript.maxCooldownTime = 3;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bullet"))
        {
            TakeDamage(); // caso a vida dele nao seja menor ou igual a 0, ele só leva dano
        }
    }
}
