using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pause : MonoBehaviour
{
    private bool isPaused;
    private bool gameStarted;
    public bool gameOver;
    public bool gameCleared;

    public GameObject pauseMenuUI;
    public GameObject startMenuUI;
    public GameObject clearedGameUI;
    private GameObject Player;
    private Health healthScript;

    private void Start()
    {
        Time.timeScale = 0;
    }

    private void Update()
    {
        if (gameStarted)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!gameCleared)
                    PauseGame();
            }
            if (Input.GetKeyDown(KeyCode.R) && isPaused)
                Restart();
        }
        if (gameOver)
            PauseGame();
    }

    public void PauseGame()
    {
        if (!isPaused)
        {
            Time.timeScale = 0;
            pauseMenuUI.SetActive(true);
            isPaused = true;
        }

        else if (isPaused && !gameOver)
        {
            Time.timeScale = 1;
            pauseMenuUI.SetActive(false);
            isPaused = false;
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Easy()
    {
        SetDifficulty(25);
    }

    public void normal()
    {
        SetDifficulty(10);
    }

    public void Hard()
    {
        SetDifficulty(3);
    }

    public void ChallengeMode()
    {
        SetDifficulty(1);
    }

    public void ImTrash()
    {
        SetDifficulty(99);
    }

    private void SetDifficulty(int amount)
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        healthScript = Player.GetComponent<Health>();
        healthScript.SetHealthBar(amount, false);

        if (amount == 99)
            healthScript.invincible = true;
        else
            healthScript.health = amount;

        StartGame();
    }

    private void StartGame()
    {
        startMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameStarted = true;
    }

    public void GameCleared()
    {
        clearedGameUI.SetActive(true);
        gameCleared = true;
        isPaused = true;
    }
}