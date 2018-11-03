using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguProjectiles : ProjectileBehaviourBase
{
    private bool atDestination;
    public GameObject Expulosion;

    private Vector3 target;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        target = Player.GetComponent<Transform>().position;

        projectileSpeed = 0.3f;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (!atDestination)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, projectileSpeed); // MoveTowards, for when you can't bother with math. no, i did do the math but I needed to link the boss (boss shot the bullet) wich by the way, i can do now. but I got stumped at the time and gave up.
            if (transform.position == target)
            {
                atDestination = true;
                Instantiate(Expulosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
