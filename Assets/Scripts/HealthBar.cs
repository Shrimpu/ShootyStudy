using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthBar;
    public float fullHealth;
    public float curHealth;

    public void HealthBarCalc(int damage)
    {
        curHealth -= damage;
        curHealth = Mathf.Clamp(curHealth, 0, fullHealth);

        healthBar.value = curHealth / fullHealth;
    }
}
