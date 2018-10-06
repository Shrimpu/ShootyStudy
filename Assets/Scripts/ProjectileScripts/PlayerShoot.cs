using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : ProjectileBase
 {

    private bool shooting;
    private float nextShot;
    public Transform projectileSpawn;

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
	
	void FixedUpdate () 
    {
        if (nextShot >= 0)
        {
            nextShot -= Time.deltaTime;
        }
        if (shooting && nextShot <= 0)
        {
            Instantiate(projectile, projectileSpawn.position, projectileSpawn.rotation);
            nextShot = firerate;
        }
	}
}
