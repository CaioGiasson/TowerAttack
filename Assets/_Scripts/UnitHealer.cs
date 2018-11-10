using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealer : Unit {

    public new IEnumerator Attack(Unit target)
    {
        float attackTime = 1 / attackSpeed;

        yield return new WaitForSeconds(0.1f);

        if (!fainted)
        {
            target.Heal(attack);
            yield return new WaitForSeconds(attackTime - 0.1f);
        }
    }

}
