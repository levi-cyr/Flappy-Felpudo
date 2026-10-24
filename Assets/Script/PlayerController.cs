using UnityEngine;

public class PlayerController : MonoBehaviour
{
    bool isClicking;
    Vector2 impulse = new Vector2(0, 300f);
    Rigidbody2D playerRb;
    public float playerSpeed = 3f;
    public Timer timerScript;
    public GameObject defeatText;
    public EnemySpawn enemySpawn;
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerVerticalMovement();
    }
    void FixedUpdate()
    {
        PlayerHorizontalMovement();
    }
    void PlayerVerticalMovement() // controla a movimentação vertical do player (click do mouse)
    {
        if (Input.GetButtonDown("Fire1"))
        {
            if (!isClicking)
            {
                isClicking = true;
            }
            playerRb.linearVelocity = new Vector2(0, 0);
            playerRb.AddForce(impulse);
        }
    }

    void PlayerHorizontalMovement() // controla a movimentação horizontal do player (A e D ou <- e ->)
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        playerRb.linearVelocityX = horizontalMovement * playerSpeed;
    }
    public void PlayerDeath() // chama a morte do player
    {
        Destroy(gameObject); // adicionar funções para a morte do player aqui
        timerScript.stopTime = true; // para o timer
        defeatText.SetActive(true); // mostra a tela de derrota
        enemySpawn.CancelEnemySpawner(); // cancela o spawn de inimigos
    }
}
