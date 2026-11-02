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
    public GameObject gameIconObj;
    
    public CanvasGroup gameIcon;
    public CanvasGroup introBackground;


    public Timer timerScript;
    public float introTime;

    public bool gameStart = false;
    public Button startButton;
    bool canFade = false;
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
            StartCoroutine("WaitToStart"); // começa uma courotine
        }
        TurnOffGameIcon();
    }
    void TurnOffGameIcon()
    {
        if (canFade)
        {
            gameIconObj.GetComponent<Animator>().enabled = false; // desativa o animator
            gameIcon.alpha = gameIcon.alpha - 0.01f; // da o fade
            Debug.Log("Movere crus");
        }

        if (gameIcon.alpha <= 0 && canFade)
        {
            canFade = false;
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

    IEnumerator WaitToStart()
    {
        canFade = true;
        Debug.Log("oye como va");
        yield return new WaitForSeconds(5f);
        startButton.onClick.Invoke(); // depois de 2 segundos da play no jogo
    }
}
