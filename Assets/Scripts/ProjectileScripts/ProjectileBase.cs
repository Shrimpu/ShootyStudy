using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBase : MonoBehaviour
{
    public AudioClip shootSound;
    private AudioSource AudioShoot;
    public GameObject[] projectile;

    [Range(50f,0.1f)]
    public float firerate;

    private void Start()
    {
        AudioShoot = gameObject.AddComponent<AudioSource>();
        AudioShoot.clip = shootSound;
        AudioShoot.loop = false;
        AudioShoot.playOnAwake = false;
        AudioShoot.volume = 0.2f;
    }

    protected virtual void ShootSound()
    {
        if (shootSound != null)
            AudioShoot.Play(0);
    }
}