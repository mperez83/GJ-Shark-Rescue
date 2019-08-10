using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstanceMaster : MonoBehaviour
{
    int score;
    public float dayTimerLength;    //In seconds
    float dayTimer;
    bool gameEnded;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    public GameObject gameOverCanvas;
    public TextMeshProUGUI finalScoreText;

    void Start()
    {
        dayTimer = dayTimerLength;
    }

    void Update()
    {
        if (!gameEnded) dayTimer -= Time.deltaTime;
        if (dayTimer <= 0 && !gameEnded)
        {
            dayTimer = 0;
            EndGame();
        }
        timerText.text = "Timer: " + dayTimer.ToString("F1");
    }

    public void AddToScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();
    }

    public void EndGame()
    {
        gameEnded = true;
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
        finalScoreText.text = "Final Score: " + score.ToString();
    }
}