using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour // this is a menu and I somehow made this retarded.
{
    private bool isPaused;
    private bool gameStarted;
    public bool gameOver;
    public bool gameCleared;
    public string difficulty;

    public GameObject pauseMenuUI;
    public GameObject startMenuUI;
    public GameObject clearedGameUI;
    private GameObject Player;
    private Health healthScript;
    public Text diedText;

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
                {
                    PauseGame();
                }
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
            Cursor.visible = true; // with all these Cursor things I followed the philosophy of shoving them down everywhere and not thinking. feel free to tell me wich are redundant.
            isPaused = true;
        }

        else if (isPaused && !gameOver)
        {
            Time.timeScale = 1;
            pauseMenuUI.SetActive(false);
            Cursor.visible = false;
            isPaused = false;
        }

        if (gameOver)
            diedText.text = "Game Over\nScore: " + GetComponent<Score>().score.ToString("0000000");
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
        Time.timeScale = 1;
        Cursor.visible = true;
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Home()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1;
        Cursor.visible = true;
    }

    public void LoadLvl1()
    {
        SceneManager.LoadScene("Level1");
        Time.timeScale = 1;
        Cursor.visible = true;
    }

    public void LoadArcade()
    {
        SceneManager.LoadScene("Arcade");
        Time.timeScale = 1;
        Cursor.visible = true;
    }

    public void Easy()
    {
        difficulty = "Easy";
        SetDifficulty(15);
    }

    public void Normal()
    {
        difficulty = "Normal";
        SetDifficulty(10);
    }

    public void Hard()
    {
        difficulty = "Hard";
        SetDifficulty(3);
    }

    public void ChallengeMode()
    {
        difficulty = "Hard";
        SetDifficulty(1);
    }

    public void ImTrash()
    {
        difficulty = "Easy";
        SetDifficulty(99);
    }

    private void SetDifficulty(int amount) // this code makes me want to cry. read at own risk.
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        healthScript = Player.GetComponent<Health>();
        healthScript.SetHealthBar(amount, false);

        if (amount == 99)
            healthScript.invincible = true;
        else
            healthScript.health = amount;

        if (difficulty == "Easy")
            GetComponent<Score>().scoreMult = 2;
        else if (difficulty == "Normal")
            GetComponent<Score>().scoreMult = 3;
        else if (difficulty == "Hard")
            GetComponent<Score>().scoreMult = 4;

        StartGame();
    }

    private void StartGame()
    {
        startMenuUI.SetActive(false);
        Time.timeScale = 1;
        gameStarted = true;
        Cursor.visible = false;
    }

    public void GameCleared()
    {
        clearedGameUI.SetActive(true);
        gameCleared = true;
        isPaused = true;
        Cursor.visible = true;
    }
} // by this point im sure that you've noticed that my placement of functions have no rime or reason. I hope to improve this with my next project.