using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenuHandler : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

    public void RestartButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Game");
    }

    public void QuitButton()
    {
        Time.timeScale = 1;
        GameMaster.instance.musicMaster.PlayMainMenuMusic();
        SceneManager.LoadScene("MainMenu");
    }
}