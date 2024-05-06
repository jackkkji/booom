using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour

{
    public int damage = 3;
    public bool InstantKillstate = false;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Enemy_Health>() != null)
        {
            Enemy_Health enemy_health = collider.GetComponent<Enemy_Health>();
            enemy_health.Damage(damage);
        }
    }


    public void ChangeDamage()
    {
         if (InstantKillstate)
        {
            damage = 3;
            InstantKillstate = false;
        }
         else if (!InstantKillstate)
         {
            damage = 999;
            InstantKillstate = true;
        }
    }






}
