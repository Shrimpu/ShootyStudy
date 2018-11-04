using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeEnemySpwnr : MonoBehaviour
{
    public GameObject[] EnemyList;
    public GameObject GameController;
    private Score score;
    private Vector2 spawnPoint;

    private float spawnrate = 4;
    private float nextSpawn;
    private int difficulty = 2000;
    private bool doOnce;

    private float random;
    private float randRange1 = 4;
    private float randRange2 = -4;

    private void Start()
    {
        if (GameController == null)
            GameController = GameObject.FindGameObjectWithTag("GameController");

        score = GameController.GetComponent<Score>();
        nextSpawn = Time.time + spawnrate;
    }

    private void FixedUpdate()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnrate;

            random = Random.Range(randRange1, randRange2);
            spawnPoint = new Vector2(transform.position.x, random);

            if (score.score < 5000)
                Instantiate(EnemyList[Random.Range(0, 4)], spawnPoint, Quaternion.identity);
            else
                Instantiate(EnemyList[Random.Range(0, EnemyList.Length)], spawnPoint, Quaternion.identity);
        }

        if (score.score >= difficulty)
        {
            if (spawnrate > 0.90f)
            {
                spawnrate -= 0.3f;
                difficulty += 3000;
                score.SetDangerText(false);
            }
            else
            {
                if (!doOnce)
                {
                    spawnrate = 0.90f;
                    score.SetDangerText(true);
                    doOnce = true;
                }
            }
        }
    }
}
