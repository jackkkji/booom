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
    }





    private void Die()
    {
        Time.timeScale = 0f;
        GameOver.SetActive(true);
    }


}
