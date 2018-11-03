using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveDemo : MonoBehaviour
{
    // this fucking code makes something move in a circle. I made this code without any references or help. please don't look at it to hard, its very fragile and may fall apart.
    // I want you to know that I alone wrote this fucking garbage so don't crucify anyone else. this is my sin.
    private void Update()
    {
        transform.position = new Vector2(Mathf.Sin(Time.realtimeSinceStartup) * Mathf.Sin(Time.realtimeSinceStartup) + 4.2f, Mathf.Sin(Time.realtimeSinceStartup * 2) * 0.5f - 1.7f);
    }
    // I want to puke.
}
