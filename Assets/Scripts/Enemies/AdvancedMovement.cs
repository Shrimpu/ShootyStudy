using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdvancedMovement : EnemyBase
{
    private float rndYPos; // Mathf.Sin fucks up the random Y from the original spawn so I did the lazy thing and assigned a new pos
    private float xPos = 11;
    private float rndIntensity;
    private float timeOfSpawn; // makes it so that the enemies are out of sync.

    void Start()
    {
        timeOfSpawn = Time.time;
        rndYPos = Random.Range(-2f, 2f);
        rndIntensity = Random.Range(2f, 4f);
    }

    protected override void MovingAbout()
    {
        xPos -= speed;
        transform.position = new Vector2(Mathf.Cos((Time.time - timeOfSpawn) * rndIntensity) * 2f + xPos, Mathf.Sin((Time.time  - timeOfSpawn) * rndIntensity) * 2f + rndYPos);
    }
}
