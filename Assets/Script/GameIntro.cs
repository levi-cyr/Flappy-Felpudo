using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameIntro : MonoBehaviour
{
    [Header("GameObjects")]
    public GameObject gameIntro;
    public GameObject player;
    public GameObject enemySpawn;
    public GameObject buttonGameObj;
    public GameObject introMusic;
    public GameObject timerGameObj;
    public GameObject planeSoundEffect;

    public CanvasGroup introBackground;
    

    public Timer timerScript;
    public float introTime;

    public bool gameStart = false;
    public Button startButton;

    void Update()
    {
        if (gameIntro.activeSelf)
        {
            timerScript.stopTime = true; // enquanto a intro estiver rolando, o tempo do jogo fica pausado
        }

        if (introBackground.alpha > 0 && gameStart) // quando o jogo começa faz um fade in para iniciar
        {
            introBackground.alpha = introBackground.alpha - 0.01f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && buttonGameObj.activeSelf) // se apertar o espaço e o botão já estiver em cena, chama a void StartGame() do botão e do script
        {
            startButton.onClick.Invoke();
        }
    }

    public void StartGame()
    {
        player.SetActive(true); // ativa o player
        planeSoundEffect.SetActive(true); // ativa o soundeffect do player
        gameStart = true; // liga a chave que inicia o jogo
        introMusic.SetActive(false); // desativa a musica da intro
        StartCoroutine("StartCooldown"); // começa o cooldown p iniciar tudo
    }

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(introTime); // espera 5 segundos para começar a spawnar inimigos e mostrar o timer
        gameIntro.SetActive(false); // desativa a intro
        timerScript.stopTime = false; // volta o tempo
        timerGameObj.SetActive(true); // ativa o obj do tempo
        enemySpawn.SetActive(true); // ativa o spawn de inimigo
    }
}
