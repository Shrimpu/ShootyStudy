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
            transform.position = Vector3.MoveTowards(transform.position, target, projectileSpeed);
            if (transform.position == target)
            {
                atDestination = true;
                Instantiate(Expulosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
