using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterAnim : MonoBehaviour
{
    private float delay = 0;
    public AudioClip sound;

	void Start ()
    {
        if (sound != null)
        {
            gameObject.AddComponent<AudioSource>().clip = sound;
            gameObject.GetComponent<AudioSource>().Play(0);
        }
        Destroy(gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
}
