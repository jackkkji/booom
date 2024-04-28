using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class World_interaction : MonoBehaviour
{
    NavMeshAgent playerAgent;



    public float sprintDistance = 0.3f; // ��̵ľ���
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

         if (Input.GetKey(KeyCode.F))    �Ȳ�Ҫ����
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
        if (Physics.Raycast(interactionRay, out interactionInfo)) // ��������Ƿ�����˳����е�����
        {
            Vector3 direction = (interactionInfo.point - transform.position).normalized; // ����ӽ�ɫ�������λ�õķ���
            Vector3 sprintTarget = transform.position + direction * sprintDistance; // �����̵�Ŀ��λ��

            playerAgent.ResetPath(); // ��ϵ�ǰ��NavMesh·��
            playerAgent.Move(sprintTarget); // �ý�ɫ��Ŀ�귽���ƶ��̶�����
            Canflash = false;
        }
    }





}
