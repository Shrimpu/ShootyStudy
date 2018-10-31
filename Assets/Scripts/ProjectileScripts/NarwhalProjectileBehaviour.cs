using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarwhalProjectileBehaviour : ProjectileBehaviourBase
{
    private void Start()
    {
        projectileSpeed = 0.25f;
    }
    void FixedUpdate ()
    {
		transform.position = new Vector2(transform.position.x - projectileSpeed, transform.position.y);
	}
}
