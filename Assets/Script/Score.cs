using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
   public int enemiesKilled = 0;
   public TMP_Text killCountText;

    void Update()
    {
        killCountText.text = "Inimigos derrotados: " + enemiesKilled;
    }
}
