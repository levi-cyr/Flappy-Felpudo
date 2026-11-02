using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int enemiesKilled = 0;
    public bool isBossDead = false;
    public GameObject boss;
    [Header("Scripts")]
    public EnemySpawn enemySpawn;
    [Header("Text")]
    public TMP_Text killCountText;

    void Update()
    {
        killCountText.text = "Score: " + enemiesKilled;
    }

    public void CallTheBoss()
    {
        if (!isBossDead)
        {
            enemySpawn.CancelEnemySpawner(); // cancela o spawn de inimigo
            boss.SetActive(true); // ativa o game objecto do boss
        }
    }
}
