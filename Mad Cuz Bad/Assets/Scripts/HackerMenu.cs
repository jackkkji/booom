using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HackerMenu : MonoBehaviour
{
    //ÏÂ»¬ÕÒ²åÈëË¢¹Ö½Å±¾µÄÌáÊ¾
    private bool Openstate = false;
    public GameObject menu;
    public GameObject D4CState;
    public GameObject PostProcess;
    public TextMeshProUGUI instantkillButtonText;
    public TextMeshProUGUI RangedAttackHackerText;
    public TextMeshProUGUI HighSpeedText;

    public bool DirtyDeedsDoneDirtCheap;
    private float timer;
    private float ResetTimer;
    private float D4CChecker;
    private float D4CValue;
    private float D4CValueTimer;

    private AttackArea instantkill;
    private RangedAttack NoCD;
    private World_interaction IShowSpeed;
    private Player_Spawn_Enemy spawner;

    private Dialogue InputEnabler;

    // Start is called before the first frame update
    void Start()
    {
        instantkill = GameObject.FindWithTag("Player").GetComponent<AttackArea>();
        NoCD = GameObject.FindWithTag("Player").GetComponent<RangedAttack>();
        IShowSpeed = GameObject.FindWithTag("Player").GetComponent<World_interaction>();
        spawner = GameObject.FindWithTag("Player").GetComponent<Player_Spawn_Enemy>();
        instantkill.InstantKillstate = false;
        NoCD.RangedAttackHacker = false;
        IShowSpeed.HighWayToHell = false;
        DirtyDeedsDoneDirtCheap = false;
        InputEnabler = GameObject.Find("DialogueBox").GetComponentInChildren<Dialogue>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("污秽度" + D4CValue);
        if (!DirtyDeedsDoneDirtCheap)
        {
            timer += Time.deltaTime;
            if (timer >= 3f)
            {
                D4CChecker = Random.Range(0f, 100f);
                if (D4CChecker < D4CValue)
                {
                    DirtyDeedsDoneDirtCheap = true;
                    timer = 0;
                    D4CValue = 0;
                }
                else
                {
                    timer = 0;
                }
            }
        }

        if (!DirtyDeedsDoneDirtCheap)
        {
            if (!InputEnabler.PlayingIntro)
            {
                if (Input.GetKeyDown(KeyCode.Tab))
                {
                    if (Openstate)
                    {
                        menu.SetActive(false);
                        Time.timeScale = 1;
                        Openstate = false;
                    }
                    else
                    {
                        menu.SetActive(true);
                        Time.timeScale = 0;
                        Openstate = true;
                    }
                }
            }
            if (instantkill.InstantKillstate)
            {
                instantkillButtonText.text = "禁用";
            }
            if (!instantkill.InstantKillstate)
            {
                instantkillButtonText.text = "启用";
            }

            if (NoCD.RangedAttackHacker)
            {
                RangedAttackHackerText.text = "禁用";
            }
            if (!NoCD.RangedAttackHacker)
            {
                RangedAttackHackerText.text = "启用";
            }

            if (IShowSpeed.HighWayToHell)
            {
                HighSpeedText.text = "禁用";
            }
            if (!IShowSpeed.HighWayToHell)
            {
                HighSpeedText.text = "启用";
            }

            if (IShowSpeed.HighWayToHell | NoCD.RangedAttackHacker | instantkill.InstantKillstate)
            {
                D4CValueTimer += Time.deltaTime;
                if (D4CValueTimer >= 1f)
                {
                    D4CValue += 1f;
                    if(IShowSpeed.HighWayToHell)
                    {
                        D4CValue += 1.5f;
                    }
                    if (NoCD.RangedAttackHacker)
                    {
                        D4CValue += 1.5f;
                    }
                    if (instantkill.InstantKillstate)
                    {
                        D4CValue += 1.5f;
                    }
                    D4CValueTimer = 0;
                }
            }
        }
        else
        {
            ResetTimer += Time.deltaTime;
            spawner.SpawnEnemies();
            if (ResetTimer == 3f)
            {
                spawner.SpawnEnemies();
            }
            if (ResetTimer == 6f)
            {
                spawner.SpawnEnemies();
            }

            if (ResetTimer <= 5f)
            {
                menu.SetActive(true);
                D4CState.SetActive(true);
                PostProcess.SetActive(true);
            }
            else
            {
                menu.SetActive(false);
                D4CState.SetActive(false);
                DirtyDeedsDoneDirtCheap = false;
                PostProcess.SetActive(false);
                ResetTimer = 0;
            }
        }
    }
}
