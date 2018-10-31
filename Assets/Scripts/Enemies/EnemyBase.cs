using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyBase : MonoBehaviour 
{
    [Range(0f,0.2f)]
    public float speed;

    Rigidbody2D rb;

	private void Start () 
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
	}

	private void FixedUpdate () 
    {
        MovingAbout();
	}

    protected virtual void MovingAbout()
    {
        transform.position = new Vector2(transform.position.x - speed, transform.position.y);
    }
}
