using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerProjectileBehaviour : ProjectileBehaviourBase
{
    private Rigidbody2D rb;
    private Vector2 direction;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        projectileSpeed = 20f;
        direction = new Vector2(1, 0);
        rb.velocity = direction.normalized * projectileSpeed;
    }
}