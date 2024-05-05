using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InstantKillSlider : MonoBehaviour
{

    public Slider InstantKillstateslider;
    GameObject Player;
    AttackArea state;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindWithTag("Player");
        state = Player.GetComponent<AttackArea>();

    }

    // Update is called once per frame
    void Update()
    {
        InstantKillstateslider.value = state.InstantKillstate;
    }
}
