using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MadBoi : Health
{
    public bool madAF;

    public override void TakeDamage(int bigHurt)
    {
        base.TakeDamage(bigHurt);
        if (madAF == false)
            GetComponent<EnemyBase>().speed *= 4;
        madAF = true;
    }
}
