using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss1Movement : EnemyBase
{
    private bool atDestination;
    private bool sinStart;
    private float sinStartTime;
    public float frequency;

    private Vector3 target;

    private void Start()
    {
        target = new Vector3(5, -1);
    }

    protected override void MovingAbout()
    {
        if (!atDestination)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
            if (transform.position == target)
            {
                atDestination = true;
            }
        }
        else
        {
            if (sinStart)
                transform.position = new Vector2(transform.position.x, Mathf.Sin((Time.time - sinStartTime) * frequency) - 0.6f);
            else
            {
                sinStartTime = Time.time;
                sinStart = true;
            }
        }
    }
}
