using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour

{
    private int damage = 3;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Enemy_Health>() != null)
        {
            Enemy_Health enemy_health = collider.GetComponent<Enemy_Health>();
            enemy_health.Damage(damage);
        }
    }


    private void ChangeDamage()
    {
 
    damage = 999;

    }






}
