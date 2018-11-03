using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackingMovement : EnemyBase // this code havn't been used and I just wrote it for fun
{
    private GameObject Player;
    private Vector3 target;

    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    protected override void MovingAbout()
    {
        target = Player.GetComponent<Transform>().position;
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
    }
}
