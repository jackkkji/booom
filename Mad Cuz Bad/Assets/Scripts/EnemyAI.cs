using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;  // 敌人的移动速度
    public float detectionDistance = 10.0f;  // 检测距离

    private NavMeshAgent Enemy1Agent;

    void Start()
    {
        Enemy1Agent = GetComponent<NavMeshAgent>();  // 获取NavMeshAgent组件
    }

    void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);  // 计算与玩家的距离

        if (distanceToPlayer <= detectionDistance)  // 如果玩家在检测距离内
        {
            Vector3 targetPosition = player.position;  // 玩家当前的位置
            Enemy1Agent.destination = targetPosition;  // 设置目标位置
        }
        else
        {
            Enemy1Agent.destination = transform.position;  // 停止移动
        }
    }
}
