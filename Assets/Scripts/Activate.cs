using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Activate : MonoBehaviour // turns on a dormant sprite
{
    private SpriteRenderer sprite;

    public void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        sprite.enabled = false;
    }

    public void ActivateSelf()
    {
        sprite.enabled = true;
    }
}
