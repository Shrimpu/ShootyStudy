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

    private void Start() // could've made a function and called it to do this but then again. this works fine... unless I want to easily change volume etc.
    {
        AudioShoot = gameObject.AddComponent<AudioSource>();
        AudioShoot.clip = shootSound;
        AudioShoot.loop = false;
        AudioShoot.playOnAwake = false;
        AudioShoot.volume = 0.2f;
    }

    protected virtual void ShootSound() // how fun
    {
        if (shootSound != null)
            AudioShoot.Play(0);
    }
}