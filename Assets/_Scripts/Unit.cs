using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    public int hp, attack, range, respawnTime, moveSpeed;
    public float attackSpeed;

    [HideInInspector] public int curHP, faintCount;
    [HideInInspector] public bool fainted;

	private void Start(){
        curHP = hp;
	}

	public void TakeDamage(int damage){
        curHP = Mathf.Max(0, curHP - damage);
        if (curHP <= 0) StartCoroutine( Faint() );
    }

    public void Heal(int amount){
        curHP = Mathf.Min(hp, curHP + amount);
    }

    public IEnumerator Faint(){
		faintCount++;
        fainted = true;
        yield return new WaitForSeconds(respawnTime);
        WakeUp();
    }

    public void WakeUp(){
        curHP = hp;
        fainted = false;
    }

    public IEnumerator Attack(Unit target){
        float attackTime = 1 / attackSpeed;

        yield return new WaitForSeconds(0.1f);

        if ( !fainted ) {
            target.TakeDamage(attack);
            yield return new WaitForSeconds(attackTime - 0.1f);
        }
    }
}
