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
            timerScript.stopTime = true;
        }

        if (introBackground.alpha > 0 && gameStart)
        {
            introBackground.alpha = introBackground.alpha - 0.01f;
        }

        if (Input.GetKeyDown(KeyCode.Space) && buttonGameObj.activeSelf)
        {
            startButton.onClick.Invoke();
        }
    }

    public void StartGame()
    {
        player.SetActive(true);
        planeSoundEffect.SetActive(true);
        gameStart = true;
        introMusic.SetActive(false);
        StartCoroutine("StartCooldown");
    }

    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(introTime);
        gameIntro.SetActive(false);
        timerScript.stopTime = false;
        timerGameObj.SetActive(true);
        enemySpawn.SetActive(true);
    }
}
