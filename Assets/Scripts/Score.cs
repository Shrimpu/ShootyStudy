using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int score;
    public Text scoreText;
    public Text finalScore;

    private void Start()
    {
        score = 0;
    }

    public void AddScore(int add)
    {
        score += add;

        SetScoreText();
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        finalScore.text = "You have won!!!\nYour final score is:\nScore: " + score.ToString();
    }
}
