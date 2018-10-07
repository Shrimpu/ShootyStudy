using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(PolygonCollider2D))]

public class Health : MonoBehaviour 
{
    [Range(1,50)]
    public int health;
    public string tag;
    public string altTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == tag || collision.gameObject.tag == altTag)
        {
            health -= 1;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
        }
        else
            print("kill yourself");
    }
}