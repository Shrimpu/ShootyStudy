using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkHealth : Health
{
    private GameObject redScreen;
    private SpriteRenderer screenRenderer;
    private Color redScreenAlpha = new Color(255f, 0f, 0f, 0f);
    private float maxHealth;

    private float timer;
    private float f = 10f;
    private bool spared;
    private bool prepared;
    private bool doOnce;

    protected override void GetShit()
    {
        base.GetShit();
        redScreen = GameObject.Find("RedScreen");
        screenRenderer = redScreen.GetComponent<SpriteRenderer>();
        maxHealth = health;
    }

    public override void TakeDamage(int bigHurt)
    {
        base.TakeDamage(bigHurt);
        RedScreen();
        timer = Time.time + f;
        if (spared == true || maxHealth / 5 >= health)
        {
            spared = false;
            if (!doOnce)
            {
                GetComponent<SharkMovement>().Enraged();
                doOnce = true;
            }
        }
        else if (maxHealth / 3 >= health && !doOnce)
        {
            GetComponent<SharkMovement>().ChangeName("Megalodon Doesn't Want To Fight");
        }
    }

    private void RedScreen()
    {
        redScreenAlpha.a += 0.4f / maxHealth;
        screenRenderer.color = redScreenAlpha;
    }

    private void FixedUpdate()
    {
        if (Time.time > timer && prepared)
        {
            spared = true;
            GetComponent<SharkMovement>().Leave();
        }
    }

    public void AbleToSpare()
    {
        timer = Time.time + f;
        prepared = true;
    }
}
