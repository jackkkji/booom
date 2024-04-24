using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class World_interaction : MonoBehaviour
{
    NavMeshAgent playerAgent;

    public float PlayerHP = 100;
    public float MaxHP = 100;


    public float sprintDistance = 0.3f; // 冲刺的距离
    public bool Candash = true;
    public float DashCoolDown = 0f;

    private void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetInteraction();
        }
        if (Input.GetKey(KeyCode.E))
        {
            if (Candash)
            {
                Dash();
            }
        }
        if (!Candash)
        {
            if (DashCoolDown >= 3f)
            {
                Candash = true;
                DashCoolDown = 0f;
            }
            else
            {
                DashCoolDown += Time.deltaTime;
            }
        }



    }

    void GetInteraction()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo, Mathf.Infinity))
        {
            GameObject interactedObject = interactionInfo.collider.gameObject;
            if(interactedObject.tag == "Interactable Object")
            {
                Debug.Log("Interactable interacted.");
            }
            else
            {
                playerAgent.destination = interactionInfo.point;    
            }
        }
    }

    void Dash()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo)) // 检测射线是否击中了场景中的物体
        {
            Vector3 direction = (interactionInfo.point - transform.position).normalized; // 计算从角色到鼠标点击位置的方向
            Vector3 sprintTarget = transform.position + direction * sprintDistance; // 计算冲刺的目标位置

            playerAgent.ResetPath(); // 打断当前的NavMesh路径
            playerAgent.Move(sprintTarget); // 让角色朝目标方向移动固定距离
            Candash = false;
        }
    }





}
