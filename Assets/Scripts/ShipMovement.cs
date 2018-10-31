using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ShipMovement : MonoBehaviour
{
    Rigidbody2D rb;

    private float xMovement;
    private float yMovement;

    [Header("Speed")]
    [Range(0f,20f)]
    public float xSpeed;
    [Range(0f,20f)]
    public float ySpeed;

	void Start () 
    {
		rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
	}
	
	void Update ()
    {
        xMovement = Input.GetAxis("Horizontal") * xSpeed;
        yMovement = Input.GetAxis("Vertical") * ySpeed;
	}

    void FixedUpdate ()
    {
        rb.velocity = new Vector2(xMovement, yMovement);
    }
}