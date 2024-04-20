using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;  //Slider�ĵ�����Ҫ����UIԴ�ļ�

public class HPCtroller : MonoBehaviour
{
    public Slider PlayerHPSlider;  //ʵ����һ��Slider
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