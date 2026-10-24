using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int enemiesKilled = 0;
    public GameObject boss;
    [Header("Scripts")]
    public EnemySpawn enemySpawn;
    [Header("Text")]
    public TMP_Text killCountText;

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
            boss.SetActive(true); // ativa o game objecto do boss
        }
    }
}
