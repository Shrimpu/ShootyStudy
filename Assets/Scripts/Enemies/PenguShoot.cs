﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguShoot : EnemyShoot
{
    private bool toggle;

    protected override void ShootingTime()
    {
        if (toggle)
        {
            Instantiate(projectile[0], projectileSpawn[0].position, projectileSpawn[0].rotation);
        }
        else
        {
            for (int i = 1; i < projectileSpawn.Length; i++)
            {
                Instantiate(projectile[i], projectileSpawn[i].position, projectileSpawn[i].rotation);
            }
        }
        toggle = !toggle;
        ShootSound();
    }
}
