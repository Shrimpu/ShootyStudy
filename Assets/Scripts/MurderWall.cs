using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MurderWall : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
            Destroy(collision.gameObject);
        else
            print("Nothing to kill makes wall sad");
    }
}