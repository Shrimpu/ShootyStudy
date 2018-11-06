using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonalSpaceRespecter : EnemyBase
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
        target = new Vector3(target.x + 4, target.y - 2f);
        if (target.y < -4.5f)
            target.y = -4.5f;
        if (target.x > 8.3f && transform.position.y < 8.3f)
            target.x = 8.3f;
        transform.position = Vector3.MoveTowards(transform.position, target, speed);
    }
}
