using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class BloodBehaviour : MonoBehaviour
{
    public float despawnTime = 30;
    private bool active;

    GameObject player;
    Vector3 playerPos;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();// Ignore
        rb.gravityScale = 0;
        rb.drag = 0.01f; // this
        rb.AddForce(transform.up * 20f); // shoots em up
        rb.AddForce(transform.right * Random.Range(-10f, 10f)); // and to the sides
        despawnTime += Time.time;
        GameObject shark = GameObject.Find("Shark"); // its called shark when I shove it on screen manually
        if (shark == null)
            shark = GameObject.Find("Shark(Clone)"); // this is what its called when its spawned by my EnemySpawner
        if (shark != null && shark.GetComponent<SharkMovement>().enraged == true)
        {
            active = true;
            player = GameObject.Find("Mola Mola");
            gameObject.AddComponent<CircleCollider2D>().radius = 0.2f; // its an addcomponent because not all should have one
        }
    }

    private void FixedUpdate()
    {
        if (despawnTime < Time.time)
            Destroy(gameObject);
        if (active)
        {
            playerPos = player.GetComponent<Transform>().position;
            transform.position = Vector3.MoveTowards(transform.position, playerPos, 0.05f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Health damage = player.GetComponent<Health>();
        damage.TakeDamage(1);

        Destroy(gameObject);
    }
}
