using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Upgrade1 : MonoBehaviour // wrote this so it would be easy to inherit (there are no other upgrades).
{
    private PlayerShoot Player;

    private void Start()
    {
        GetStuff();
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Effect(collision);
            Death();
        }
    }

    protected virtual void Effect(Collision2D collision)
    {
        Player = collision.gameObject.GetComponent<PlayerShoot>();
        Player.upgraded = true;

        GameObject turret = GameObject.Find("Turret");
        Activate script = turret.GetComponent<Activate>();
        script.ActivateSelf();
    }

    protected virtual void Movement()
    {
        transform.position = new Vector2(transform.position.x - 0.035f, transform.position.y);
    }

    protected virtual void GetStuff()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.drag = 0;
        rb.angularDrag = 0;
        rb.mass = 0.001f;
    }

    protected virtual void Death()
    {
        Destroy(gameObject);
    }
}
