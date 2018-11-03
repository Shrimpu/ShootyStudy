using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerProjectileBehaviour : ProjectileBehaviourBase
{
    private Rigidbody2D rb;
    private Vector2 direction;

    public GameObject[] blood;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        projectileSpeed = 20f;
        direction = new Vector2(1, 0);
        rb.velocity = direction.normalized * projectileSpeed;
    }

    protected override void DestroyProjectile(Collision2D collision)
    {
        Destroy(gameObject);
        if (collision.gameObject.name == "Shark" || collision.gameObject.name == "Shark(Clone)") // only shark bleeds, everyone knows that
        {
            if (Random.Range(0, 5) == 1)
            {
                Instantiate(blood[Random.Range(0, blood.Length)], transform.position, Quaternion.identity);
            }
        }
    }
}