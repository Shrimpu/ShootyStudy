﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChoppyMovement : EnemyBase
{
    public float moveTime;
    private float toggle;
    private bool moving = false;
    private bool justSpawned = true;

    private void Start()
    {
        toggle = Time.time;
    }

    protected override void MovingAbout()
    {
        if (justSpawned != true)
        {
            if (toggle < Time.time)
            {
                toggle = Time.time + moveTime;
                moving = !moving;
            }

            if (moving == true)
            {
                base.MovingAbout();
            }
        }
        else
        {
            base.MovingAbout();
            if (toggle + (moveTime * 2) < Time.time)
                justSpawned = false;
        }
    }
}
