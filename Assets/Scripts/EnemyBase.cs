using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBase : MonoBehaviour 
{
    [Range(0f,0.05f)]
    public float speed;
    [Range(1,200)]
    public float despawnTime;

    Rigidbody2D rb;

	void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
	}

	void FixedUpdate () 
    {
		transform.position = new Vector3(transform.position.x - speed, transform.position.y);
        if (despawnTime > 0)
        {
            despawnTime -= Time.deltaTime;
        }
        else if (despawnTime <= 0)
        {
            Destroy(gameObject);
        }
	}
}
