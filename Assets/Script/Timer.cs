using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timeLevel_txt;
    public static float timeLevel = 60f;
    public static bool stopTime;
    void Start()
    {
        stopTime = false;
    }

    void Update()
    {
        if (stopTime == false)
        {
            timeLevel = timeLevel - Time.deltaTime;
            timeLevel_txt.text = "Tempo: " + timeLevel.ToString("F0");
        }
    } 
}
