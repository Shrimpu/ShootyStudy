using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class ProjectileBehaviourBase : MonoBehaviour 
{

    [Range(0f,2f)]
    public float projectileSpeed;
    [Range(0,3)]
    public int projectileDamage;
    [Range(0f,10f)]
    public float despawnTime;

    private void OnCollisionEnter2D(Collider2D col)
    {
        if (col != null)
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        despawnTime -= Time.deltaTime;
        if(despawnTime <= 0)
        {
            Destroy(gameObject);
        }
    }
}
