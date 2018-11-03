using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int rawScore;
    public int score;
    public int scoreMult;
    public Text scoreText;
    public Text finalScore;

    private void Start()
    {
        rawScore = 0;
    }

    public void AddScore(int add)
    {
        rawScore += add;
        score += add * scoreMult;

        SetScoreText();
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
        finalScore.text = "You have won!!!\nYour final score is:\nScore: " + score.ToString();
    }
}
