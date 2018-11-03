using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject GameController;
    private GameObject[] enemiesOnScreen;
    private Score score;
    [Range(0.1f, 10f)]
    public float spawnRate;
    private float nextSpawn;
    private float spawnBreak;

    private bool spawnSpeedChange;
    private bool boss1Spawned;
    private bool boss2Spawned;
    private bool killMe;

    private Vector2 spawnPoint;

    private float random;
    private float randRange1 = 4;
    private float randRange2 = -4;

    [Header("Enemies")]
    public GameObject[] EnemyList;
    public GameObject[] BossList;

    private void Start()
    {
        if (GameController == null)
            GameController = GameObject.FindGameObjectWithTag("GameController");

        score = GameController.GetComponent<Score>();
        nextSpawn = spawnRate;
    }

    private void FixedUpdate()
    {
        if (Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnRate;

            random = Random.Range(randRange1, randRange2);
            spawnPoint = new Vector2(transform.position.x, random);

            if (score.rawScore < 500)
                Instantiate(EnemyList[0], spawnPoint, Quaternion.identity);
            else if (score.rawScore < 1000)
                Instantiate(EnemyList[Random.Range(0, 2)], spawnPoint, Quaternion.identity);
            else if (score.rawScore < 2000)
            {
                if (!spawnSpeedChange)
                {
                    spawnRate *= 2f;
                    spawnSpeedChange = true;
                }
                Instantiate(EnemyList[Random.Range(1, 3)], spawnPoint, Quaternion.identity);
            }
            else if (!boss1Spawned)
            {
                enemiesOnScreen = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemiesOnScreen.Length == 0)
                {
                    Instantiate(BossList[0], spawnPoint, Quaternion.identity);
                    spawnBreak = score.rawScore;
                    boss1Spawned = true;
                }
            }
            else if (score.rawScore < 7000 && spawnBreak != score.rawScore)
            {
                if (spawnSpeedChange)
                {
                    spawnRate /= 2;
                    spawnSpeedChange = false;
                }
                Instantiate(EnemyList[Random.Range(2, 4)], spawnPoint, Quaternion.identity);
            }
            else if (!boss2Spawned)
            {
                enemiesOnScreen = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemiesOnScreen.Length == 0)
                {
                    Instantiate(BossList[1], spawnPoint, Quaternion.identity);
                    spawnBreak = score.rawScore;
                    boss2Spawned = true;
                }
            }
            else
            {
                enemiesOnScreen = GameObject.FindGameObjectsWithTag("Enemy");
                if (enemiesOnScreen.Length == 0)
                    GameWon();
            }
        }
    }

    private void GameWon()
    {
        Pause won = GameController.GetComponent<Pause>();
        won.GameCleared();
    }
}
