using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMovement : EnemyBase
{
    private bool atDestination;
    private Vector3 target;

    public bool enraged;
    private bool spared;
    private bool doOnce;

    private void Start()
    {
        target = new Vector3(1, 0.5f);
        transform.position = new Vector2(transform.position.x + 2.5f, transform.position.y);
    }

    protected override void MovingAbout()
    {
        if (!atDestination)
        {
            transform.position = Vector3.MoveTowards(transform.position, target, speed);
            if (transform.position == target && !enraged)
            {
                if (!doOnce)
                {
                    doOnce = true;
                    atDestination = true;
                    GetComponent<SharkHealth>().AbleToSpare();
                    ChangeName("It Doesn't Seem Hostile");
                }
                if (spared)
                {
                    GameObject gc = GameObject.Find("GameController");
                    Pause won = gc.GetComponent<Pause>();
                    won.GameCleared();
                    Destroy(gameObject);
                }
            }
        }
    }

    public void Leave()
    {
        target = new Vector3(10, -9);
        atDestination = false;
        ChangeName("You Spared the Megalodon");
        spared = true;
    }

    public void Enraged()
    {
        target = new Vector3(1, 0.5f);
        atDestination = false;
        ChangeName("Enraged Megalodon");
        enraged = true;
    }

    public void ChangeName(string name)
    {
        GameObject gc = GameObject.Find("GameController");
        gc.GetComponent<HealthBar>().SetBossName(name);
    }
}
