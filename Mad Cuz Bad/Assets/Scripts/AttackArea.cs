using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour

{
    private int damage = 3;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider collider)
    {
        Health health = collider.GetComponent<Health>();
        health.Damage(damage);
    }
    
        
    


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
