using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public float MAX_HEALTH = 100;
    public GameObject GameOver;

    [SerializeField] public float health = 100;


    // Update is called once per frame
    void Update()
    {
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative damage");
            Die();
        }

        this.health -= amount;
        if (this.health <= 0)
        {
            Die();
        }
    }





    private void Die()
    {
        Time.timeScale = 0;
        GameOver.SetActive(true);
    }


}
