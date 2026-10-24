using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int enemiesKilled = 0;
    [Header("Scripts")]
    public EnemySpawn enemySpawn;
    Timer timerScript;
    [Header("Text")]
    public TMP_Text killCountText;

    void Start()
    {
        timerScript = timerScript.GetComponent<Timer>();
    }
    void Update()
    {
        killCountText.text = "Inimigos derrotados: " + enemiesKilled;
        CallTheBoss();
    }

    void CallTheBoss()
    {
        if (enemiesKilled >= 10)
        {
            enemySpawn.CancelEnemySpawner(); // cancela o spawn de inimigo
        }
    }
}
