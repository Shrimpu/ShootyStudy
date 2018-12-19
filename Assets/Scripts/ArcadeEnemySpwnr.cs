using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcadeEnemySpwnr : MonoBehaviour
{
    public GameObject[] EnemyList;
    [Header("GameController")]
    public GameObject GameController;
    private Score score;
    private Vector2 spawnPoint;

    private float spawnrate = 3.5f;
    private float nextSpawn;
    private int difficulty = 1000; // when score passes 1000, turn up difficulty
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

            if (score.score < 5000) // spawns enemies based on score
                Instantiate(EnemyList[Random.Range(0, 4)], spawnPoint, Quaternion.identity);
            else
                Instantiate(EnemyList[Random.Range(0, EnemyList.Length)], spawnPoint, Quaternion.identity); // this allows all enemies to sapwn including the fire fish oliver drew that has the most annoying mechanic ever.
        }

        if (score.score >= difficulty) // all of this should be a function
        {
            if (spawnrate > 0.95f)
            {
                spawnrate -= 0.5f;
                difficulty += 1000;
                score.SetDangerText(false);
            }
            else
            {
                if (!doOnce)
                {
                    spawnrate = 0.95f;
                    score.SetDangerText(true);
                    doOnce = true;
                }
            }
        }
    }
}
