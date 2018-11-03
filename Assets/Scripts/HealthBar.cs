using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour // this takes care of all my health bars. all two of them
{
    public Text bossNameText;
    public Slider healthBar;
    public Slider bossHealthBar;
    public float fullHealth;
    public float curHealth;
    public float bossFullHealth;
    public float bossCurHealth;

    private Health bossHealth;
    private SharkHealth bossHealthS;

    private string pengu = "Gun Pengu";
    private string shark = "Megalodon";

    public void HealthBarCalc(int damage, bool boss)
    {
        if (!boss)
        {
            curHealth -= damage;
            curHealth = Mathf.Clamp(curHealth, 0, fullHealth);

            healthBar.value = curHealth / fullHealth;
        }
        else
        {
            bossCurHealth -= damage;
            bossCurHealth = Mathf.Clamp(bossCurHealth, 0, bossFullHealth);

            bossHealthBar.value = bossCurHealth / bossFullHealth;
            if (bossHealthBar.value <= 0)
                bossNameText.text = "";
        }
    }

    public void SetBossHealth(string bossName)
    {
        GameObject boss = GameObject.Find(bossName);
        if (bossName == "PenguBoss" || bossName == "PenguBoss(Clone)")
        {
            bossHealth = boss.GetComponent<Health>();
            bossHealth.SetHealthBar(bossHealth.health, true);
        }
        else
        {
            bossHealthS = boss.GetComponent<SharkHealth>();
            bossHealthS.SetHealthBar(bossHealthS.health, true);
        }
        SetBossName(bossName);
    }

    public void SetBossName(string bossName)
    {
        if (bossName == "PenguBoss(Clone)")
            bossName = pengu;
        else if (bossName == "Shark(Clone)")
            bossName = shark;
        bossNameText.text = (bossName);
    }
}
