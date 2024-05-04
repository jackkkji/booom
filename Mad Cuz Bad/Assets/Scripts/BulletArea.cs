using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;




public class BulletArea : MonoBehaviour

{

    private int damage = 20;




    // Start is called before the first frame update


    private void OnTriggerEnter(Collider collider)
    {

        if (collider.GetComponent<Health>() != null)
        {
            Health health = collider.GetComponent<Health>();
            health.Damage(damage);
        }

    }
}