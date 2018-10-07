using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : ProjectileBase
{
	private float nextShot;
    public Transform projectileSpawn;

    void start()
    {
        nextShot = firerate;
    }

	void FixedUpdate () 
    {
		if (nextShot >= 0)
        {
            nextShot -= Time.deltaTime;
        }
        if (nextShot <= 0)
        {
            Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
            nextShot = firerate;
        }
	}
}
