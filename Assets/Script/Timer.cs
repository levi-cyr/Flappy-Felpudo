using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public TMP_Text timer;
    public float timeLeft = 60f;
    public bool stopTime;
    void Start()
    {
        stopTime = false;
    }

    void Update()
    {
        if (stopTime == false)
        {
            timeLeft = timeLeft - Time.deltaTime;
            timer.text = "Tempo: " + timeLeft.ToString("F0");
        }
    } 
}
