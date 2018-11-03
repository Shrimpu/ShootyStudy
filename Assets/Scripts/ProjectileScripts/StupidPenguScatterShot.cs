using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StupidPenguScatterShot : ProjectileBehaviourBase
{
    public bool up;
    public bool down;

    private Rigidbody2D rb;
    private Vector2 direction;

    private void Start() // sad
    {
        projectileSpeed = 5f;

        if (up)
            direction = new Vector2(-2, 1);
        else if (down)
            direction = new Vector2(-2, -1);
        else
            direction = new Vector2(-1, 0);
        direction = direction.normalized;
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rb.velocity = direction * projectileSpeed;
    }
}
