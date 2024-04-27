using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //Slider你说你🐎呢

public class HPCtroller : MonoBehaviour
{
    public Slider PlayerHPSlider;  //说的道理Slider
    Health health8;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        health8 = Player.GetComponent<Health>();
    }

    void Update()
    {
        PlayerHPSlider.value = health8.health / health8.MAX_HEALTH;
    }
}