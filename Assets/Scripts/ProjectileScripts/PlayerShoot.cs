using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : ProjectileBase
{
    public bool upgraded;
    private bool shooting;
    private float nextShot;
    public Transform[] projectileSpawn;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shooting = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            shooting = false;
        }
    }

    void FixedUpdate()
    {
        if (!upgraded)
            StandardShoot();
        else if (upgraded)
            AdvancedShoot();
    }

    void StandardShoot()
    {
        if (nextShot >= 0)
        {
            nextShot -= Time.deltaTime;
        }
        if (shooting && nextShot <= 0)
        {
            Instantiate(projectile[0], projectileSpawn[0].position, projectileSpawn[0].rotation);
            nextShot = firerate;
            ShootSound();
        }
    }

    void AdvancedShoot()
    {
        if (nextShot >= 0)
        {
            nextShot -= Time.deltaTime;
        }
        if (shooting && nextShot <= 0)
        {
            for (int i = 0; i < projectileSpawn.Length; i++)
            {
                Instantiate(projectile[i], projectileSpawn[i].position, projectileSpawn[i].rotation);
                nextShot = firerate;
            }
            ShootSound();
        }
    }
}