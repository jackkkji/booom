using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class World_interaction : MonoBehaviour
{
    NavMeshAgent playerAgent;



    public float sprintDistance = 0.3f; // 冲刺的距离
    public bool Canflash = true;
    public float FlashCoolDown = 0f;
    private Animator animator;

    private void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetInteraction();
        }
        

        if (playerAgent.remainingDistance < 0.5f)
        {
            animator.SetBool("PMC_Moving", false);
        }

        /* if (playerAgent.isPathStale)
         {
             animator.SetTrigger("PMC_Moving");
         }

         if (Input.GetKey(KeyCode.F))    先不要闪现
         {
             if (Canflash)
             {
                 Flash();
             }
         }
         if (!Canflash)
         {
             if (FlashCoolDown >= 3f)
             {
                 Canflash = true;
                 FlashCoolDown = 0f;
             }
             else
             {
                 FlashCoolDown += Time.deltaTime;
             }
         }*/



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
                animator.SetBool("PMC_Moving", true);
            }
        }
    }

    void Flash()
    {
        Ray interactionRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit interactionInfo;
        if (Physics.Raycast(interactionRay, out interactionInfo)) // 检测射线是否击中了场景中的物体
        {
            Vector3 direction = (interactionInfo.point - transform.position).normalized; // 计算从角色到鼠标点击位置的方向
            Vector3 sprintTarget = transform.position + direction * sprintDistance; // 计算冲刺的目标位置

            playerAgent.ResetPath(); // 打断当前的NavMesh路径
            playerAgent.Move(sprintTarget); // 让角色朝目标方向移动固定距离
            Canflash = false;
        }
    }





}
