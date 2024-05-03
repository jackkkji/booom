using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour

{
    private int damage = 3;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }
    }


    private void ChangeDamage(int damage)
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            damage = 999;
        }
    }






}
