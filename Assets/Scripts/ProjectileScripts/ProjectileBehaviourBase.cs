using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ProjectileBehaviourBase : MonoBehaviour
{
    protected GameObject Player;

    protected float projectileSpeed;
    [Range(0, 3)]
    public int projectileDamage;
    [Range(0f, 15f)]
    public float despawnTime;
    public string targetTag;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == targetTag)
        {
            Player = GameObject.FindGameObjectWithTag("Player");

            if (Player != null)
            {
                Health damage = Player.GetComponent<Health>();
                damage.TakeDamage(projectileDamage);
            }
        }
        DestroyProjectile(collision);
    }

    void Update()
    {
        despawnTime -= Time.deltaTime;
        if (despawnTime <= 0)
        {
            Destroy(gameObject);
        }
    }

    protected virtual void DestroyProjectile(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
