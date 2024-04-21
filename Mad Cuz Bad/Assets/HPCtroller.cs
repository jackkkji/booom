using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //Slider的调用需要引用UI源文件

public class HPCtroller : MonoBehaviour
{
    public Slider PlayerHPSlider;  //实例化一个Slider
    World_interaction PlayerHP;
    GameObject Player;

    private void Start()
    {
        Player = GameObject.FindWithTag("Player");
        PlayerHP = Player.GetComponent<World_interaction>();
    }

    void Update()
    {
        PlayerHPSlider.value = PlayerHP.PlayerHP / PlayerHP.MaxHP;
    }
}