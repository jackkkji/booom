using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f; // 敌人的移动速度
    UnityEngine.AI.NavMeshAgent Enemy1Agent;


    void Start()
    {
        Enemy1Agent = GetComponent<NavMeshAgent>(); // 获取Rigidbody
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = player.position; // 玩家当前的位置
        Enemy1Agent.destination = targetPosition;
    }
}
