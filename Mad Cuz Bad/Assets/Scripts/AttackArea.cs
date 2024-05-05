using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour

{
    public int damage = 3;
    public int InstantKillstate = 0;

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
        damage = 999;
        if (InstantKillstate == 0)
       {
            damage = 999;
            InstantKillstate = 1;
        }
        if (InstantKillstate == 1)
        {
            damage = 3;
            InstantKillstate = 0;
        } 
    }






}
