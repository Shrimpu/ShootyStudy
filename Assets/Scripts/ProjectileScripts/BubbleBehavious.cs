using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleBehavious : ProjectileBehaviourBase
{
    private Rigidbody2D rb;
    [Range(0.001f, 0.1f)]
    public float nutForce;

    private Vector3 target;
    private Vector3 targetOffset;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        target = Player.GetComponent<Transform>().position;

        ExtraFeatures();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        if (Player != null)
        {
            target = Player.GetComponent<Transform>().position;
            transform.position = Vector3.MoveTowards(transform.position, target + targetOffset, projectileSpeed);
        }
    }

    protected void ExtraFeatures()
    {
        projectileSpeed = 0.05f;

        targetOffset = new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f));

        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * nutForce * Random.Range(0.6f, 1.8f));
        rb.AddForce(transform.right * nutForce * Random.Range(0.6f, 1.5f));
    }
}
