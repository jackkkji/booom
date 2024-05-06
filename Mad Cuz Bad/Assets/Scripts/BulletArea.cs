using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class BulletArea : MonoBehaviour

{

    private int damage = 20;
    private float timer = 0f;




    // Start is called before the first frame update


    private void OnTriggerEnter(Collider collider)
    {

        if (collider.GetComponent<Enemy_Health>() != null)
        {
            Enemy_Health health = collider.GetComponent<Enemy_Health>();
            health.Damage(damage);
            Destroy(gameObject);
        }

    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 1f)
        {
            Destroy(gameObject);
        }
    }
}