using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectileBehaviour : ProjectileBehaviourBase
{
    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + projectileSpeed, transform.position.y);
    }
}