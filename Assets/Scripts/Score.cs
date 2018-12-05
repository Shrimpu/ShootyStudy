using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public int rawScore;
    public int score;
    public int scoreMult; // this is here so that the different difficulties give different amount of score.
    static int danger = 1;

    public Text scoreText;
    public Text finalScore;
    public Text dangerText;

    private void Start()
    {
        rawScore = 0;
        SetScoreText();
        danger = 1;
    }

    public void AddScore(int add)
    {
        rawScore += add;
        score += add * scoreMult;

        SetScoreText();
    }

    void SetScoreText()
    {
        scoreText.text = "Score: " + score.ToString("0000000");
        if (finalScore != null)
            finalScore.text = "You have won!!!\nYour final score is:\nScore: " + score.ToString("0000000");
    }

    public void SetDangerText(bool max)
    {
        if (dangerText != null)
        {
            danger += 1;
            if (!max)
                dangerText.text = "Danger: " + danger;
            else
                dangerText.text = "Danger: MAX";

            if (danger == 5)
            {
                GameObject turret = GameObject.Find("Turret");
                turret.GetComponent<Activate>().ActivateSelf();
                GameObject player = GameObject.Find("Mola Mola");
                player.GetComponent<PlayerShoot>().upgraded = true;
            }
        }
    }
}
