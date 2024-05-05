using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class BulletArea : MonoBehaviour

{

    private int damage = 20;




    // Start is called before the first frame update


    private void OnTriggerEnter(Collider collider)
    {

        if (collider.GetComponent<Enemy_Health>() != null)
        {
            Enemy_Health health = collider.GetComponent<Enemy_Health>();
            health.Damage(damage);
        }

    }
}