using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveMovement : EnemyBase
{
    private float rndYPos;
    private float rndIntensity;
    private float timeOfSpawn;

    private void Start()
    {
        timeOfSpawn = Time.time;
        rndYPos = Random.Range(-3f, 3f);
        rndIntensity = Random.Range(1.5f, 3f);
    }

    protected override void MovingAbout()
    {
        transform.position = new Vector2(transform.position.x - speed, Mathf.Sin((Time.time - timeOfSpawn) * rndIntensity) + rndYPos);
    }
}