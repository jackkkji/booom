using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    public Transform player;
    public float speed = 5.0f; // 敌人的移动速度

    private Rigidbody rb; // 引用敌人的Rigidbody

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // 获取Rigidbody
    }

    void FixedUpdate()
    {
        Vector3 position = transform.position; // 敌人当前的位置
        Vector3 targetPosition = player.position; // 玩家当前的位置
        Vector3 direction = (targetPosition - position).normalized; // 计算方向

        // 使用Rigidbody的MovePosition进行移动
        rb.MovePosition(rb.position + direction * speed * Time.fixedDeltaTime);

        //我宣布GPT暂时是我叠
    }
}
