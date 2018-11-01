using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BloodBehaviour : MonoBehaviour
{
    public float despawnTime = 30;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        rb.drag = 0.01f;
        rb.AddForce(transform.up * 20f);
        rb.AddForce(transform.right * Random.Range(-10f, 10f));
        despawnTime += Time.time;
    }

    private void FixedUpdate()
    {
        if (despawnTime < Time.time)
            Destroy(gameObject);
    }
}
