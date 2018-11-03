using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    //this place is hell. you may want to turn back now while your brain is still in a solid state.

    public GameObject GameController; // I can't defend this mess of variables. I just kept adding more and now its a mess.
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
            nextSpawn = Time.time + spawnRate; // basic timer

            random = Random.Range(randRange1, randRange2); // this is for the y position spawn. im so sorry
            spawnPoint = new Vector2(transform.position.x, random); // this should've been its own function. that way the fat bosses doesn't spawn inside the damn screen.

            if (score.rawScore < 500) // rawScore were originally score so yeah. the 500 could've been a 5 and a lot neater. I just can't bother changing it. it works and as long as i don't touch it, it keeps working.
                Instantiate(EnemyList[0], spawnPoint, Quaternion.identity); // this code is hardcore ripped. I have no clue what Quaternion.Identity is.
            else if (score.rawScore < 1000)
                Instantiate(EnemyList[Random.Range(0, 2)], spawnPoint, Quaternion.identity);
            else if (score.rawScore < 2000) // all of this with the rawScore is sorta the level.
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
                if (enemiesOnScreen.Length == 0) // this sure is neat. I legitimately like this.
                {
                    Instantiate(BossList[0], spawnPoint, Quaternion.identity);
                    spawnBreak = score.rawScore; // this is confusing. sorry
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