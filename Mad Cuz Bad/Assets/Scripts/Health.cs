using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MAX_HEALTH = 100;

    [SerializeField] public float health = 100;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            // Damage(10);
        }    
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
        }

        this.health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }



    private void Die()
    {
        Debug.Log("Dead!");
        Destroy(gameObject);
    }


}
