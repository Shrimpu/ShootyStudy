using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int rawScore;
    public int score;
    public int scoreMult; // this is here so that the different difficulties give different amount of score.

    public Text scoreText;
    public Text finalScore;

    private void Start()
    {
        rawScore = 0;
        SetScoreText();
    }

    public void AddScore(int add)
    {
        rawScore += add;
        score += add * scoreMult;

        SetScoreText();
    }

    void SetScoreText() // score means NOTHING in my game
    {
        scoreText.text = "Score: " + score.ToString("000000");
        finalScore.text = "You have won!!!\nYour final score is:\nScore: " + score.ToString();
    }
}
