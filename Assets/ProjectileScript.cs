using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{

    public GameObject projectile;

    [Range(1f,0.1f)]
    public float firerate;
    [Range(0f,10f)]
    public float projectileSpeed;
    [Range(0,3)]
    public int projectileDamage;
}