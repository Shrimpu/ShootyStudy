using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{

    public GameObject projectile;

    [Range(1f,0.1f)]
    public float firerate;
}