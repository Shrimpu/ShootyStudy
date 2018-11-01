using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkHealth : Health
{
    private GameObject redScreen;
    private SpriteRenderer screenRenderer;
    private Color redScreenAlpha = new Color(255f, 0f, 0f, 0f);
    private float maxHealth;

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
    }

    private void RedScreen()
    {
        redScreenAlpha.a += 0.4f / maxHealth;
        screenRenderer.color = redScreenAlpha;
    }
}
