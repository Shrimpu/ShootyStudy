using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : ProjectileBase
{
	private float nextShot;
    public Transform[] projectileSpawn;

	void FixedUpdate () 
    {
		if (nextShot <= firerate)
        {
            nextShot += Time.deltaTime;
        }
        if (nextShot >= firerate)
        {
            ShootingTime();
            nextShot = 0;
        }
	}

    protected virtual void ShootingTime()
    {
        for (int i = 0; i < projectileSpawn.Length; i++)
        {
            Instantiate(projectile[i], projectileSpawn[i].position, projectileSpawn[i].rotation);
        }
        ShootSound();
    }
}
