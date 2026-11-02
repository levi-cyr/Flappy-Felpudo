using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isClicking;
    Vector2 impulse = new Vector2(0, 300f);
    Rigidbody2D playerRb;

    [Header("Player Controller")]
    public float playerSpeed = 3f;
    public int currentLife = 4;
    public GameObject[] heartIcons;
    public bool canMove = true;

    [Header("Scripts")]
    public Timer timerScript;
    public EnemySpawn enemySpawn;

    [Header("Game Objects")]
    public GameObject defeatText;
    public GameObject planeSound;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerVerticalMovement();
    }

    void PlayerVerticalMovement() // controla a movimentação vertical do player (click do mouse)
    {
        if (Input.GetButtonDown("Fire1") && canMove)
        {
            if (!isClicking)
            {
                isClicking = true;
            }
            playerRb.linearVelocity = new Vector2(0, 0);
            playerRb.AddForce(impulse);
        }
    }

    public void TakeDamage(int damage = 1) // chama a morte do player
    {
        currentLife -= damage; // o dano base é 1. Talvez eu coloque que o boss de 2 de dano na terceira fase (ou na segunda, nao sei se vou prosseguir com uma terceira fase)

        UpdateHeartUI();

        if(currentLife <= 0)
        {
            PlayerDeath();
        }
    }
    void UpdateHeartUI()
    {
        for (int i = 0; i < heartIcons.Length; i++) // loopa a quantidade de gameobject do coração que tem na cena para poder atualizar
        {
            heartIcons[i].SetActive(i < currentLife); // se o valor que o loop esta (i) for maior que a vida atual, 
            // ele desativa esse valor e se for menor ele ativa. Caso a vida atual for igual ao valor do loop, ele tambem desativa
        }
    }
    public void PlayerDeath()
    {
        Destroy(gameObject);
        timerScript.stopTime = true; // para o timer
        defeatText.SetActive(true); // mostra a tela de derrota
        planeSound.SetActive(false);
        enemySpawn.CancelEnemySpawner(); // cancela o spawn de inimigos
    }
}
