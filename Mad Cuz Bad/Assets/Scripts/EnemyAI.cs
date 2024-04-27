using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f;
    public float detectionDistance = 10.0f;
    public float sightRange = 20.0f;  // 视线范围
    public float attackRange = 5.0f;  // 攻击范围

    private NavMeshAgent Enemy1Agent;
    private Vector3 startPosition;
    private enum State { Patrolling, Chasing, Attacking }
    private State currentState;

    void Start()
    {
        Enemy1Agent = GetComponent<NavMeshAgent>();
        startPosition = transform.position;  // 记录起始位置
        currentState = State.Patrolling;  // 初始状态为巡逻
        InitPatrol();  // 初始化巡逻点
    }

    void FixedUpdate()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (currentState == State.Patrolling)
        {
            Patrol();
            if (distanceToPlayer <= sightRange)
            {
                currentState = State.Chasing;  // 看到玩家，开始追击
            }
        }
        else if (currentState == State.Chasing)
        {
            Chase();
            if (distanceToPlayer <= attackRange)
            {
                currentState = State.Attacking;  // 玩家进入攻击范围，开始攻击
            }
            else if (distanceToPlayer > sightRange)
            {
                currentState = State.Patrolling;  // 玩家离开视线范围，返回巡逻
            }
        }
        else if (currentState == State.Attacking)
        {
            Attack();
            if (distanceToPlayer > attackRange)
            {
                currentState = State.Chasing;  // 玩家离开攻击范围，重新追击
            }
        }
    }

    void InitPatrol()
    {
        // 初始化巡逻点
        Vector3 patrolDirection = Random.insideUnitSphere * detectionDistance;
        patrolDirection += startPosition;
        NavMeshHit hit;
        if (NavMesh.SamplePosition(patrolDirection, out hit, detectionDistance, 1))
        {
            Enemy1Agent.destination = hit.position;
        }
    }

    void Patrol()
    {
        // 巡逻行为，可以是随机移动到附近的点
        if (Enemy1Agent.remainingDistance < 0.5f)
        {
            Vector3 randomDirection = Random.insideUnitSphere * detectionDistance;
            randomDirection += startPosition;
            NavMeshHit hit;
            if (NavMesh.SamplePosition(randomDirection, out hit, detectionDistance, 1))
            {
                Vector3 finalPosition = hit.position;
                Enemy1Agent.destination = finalPosition;
                UnityEngine.Debug.Log("Patrolling - New point set.");
            }
        }
    }

    void Chase()
    {
        // 追击行为
        Enemy1Agent.destination = player.position;
        UnityEngine.Debug.Log("Chasing the player!");
    }

    void Attack()
    {
        // 攻击行为
        UnityEngine.Debug.Log("Attacking the player!");
    }
}
