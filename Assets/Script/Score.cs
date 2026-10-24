using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    public int enemiesKilled = 0;
    public TMP_Text killCountText;
    public EnemySpawn enemySpawn;
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
