using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMovement : EnemyBase
{
    private bool atDestination;
    private Vector3 target;

    private void Start()
    {
        target = new Vector3(1, 0.5f);
        transform.position = new Vector2(transform.position.x + 2.5f, transform.position.y);
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
    }
}
