using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartForce : MonoBehaviour
{
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.up * Random.Range(-8f, 8f));
        rb.AddForce(Vector2.right * Random.Range(-2f, 3f));
    }
}
