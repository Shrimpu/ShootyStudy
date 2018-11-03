using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ClamProjectileBehaviour : ProjectileBehaviourBase
{
    private Rigidbody2D rb;
    private Vector2 direction;
    public bool left;
    public bool up;
    public bool stationaryX;
    public bool stationaryY;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        projectileSpeed = 5;

        CalculateDirection();
        Move();
    }

    private void CalculateDirection() // this is the code when someone gives up
    {
        if (stationaryX)
            direction.x = 0;
        else if (left)
            direction.x = -1;
        else
            direction.x = 1;

        if (stationaryY)
            direction.y = 0;
        else if (up)
            direction.y = 1;
        else
            direction.y = -1;
    }

    private void Move()
    {
        rb.velocity = direction.normalized * projectileSpeed;
    }
}
