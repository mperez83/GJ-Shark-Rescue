using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InstanceMaster : MonoBehaviour
{
    int score;
    int currency;
    public float dayTimerLength;    //In seconds
    float dayTimer;
    bool gameEnded;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timerText;

    public TextMeshProUGUI shopTrashCurrencyText;

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

    public void AddToTimer(float amount)
    {
        dayTimer += amount;
    }

    public void AddToScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score.ToString();

        currency += amount;
        shopTrashCurrencyText.text = "Trash Currency: " + currency;
    }

    public int GetCurrency()
    {
        return currency;
    }

    public bool GetGameEnded()
    {
        return gameEnded;
    }

    public void SubtractFromCurrency(int amount)
    {
        currency -= amount;
    }

    public void EndGame()
    {
        gameEnded = true;
        Time.timeScale = 0;
        gameOverCanvas.SetActive(true);
        finalScoreText.text = "Final Score: " + score.ToString();
    }
}