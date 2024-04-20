using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // 目标对准玩家
    public float height = 10f; // 摄像机距离玩家高度
    public float distance = 10f; // 摄像机后退距离（Z轴）
    public float smoothing = 5f; // 摄像机移动平滑度

    void Start()
    {
        // 摄像机初始位置
        transform.position = target.position + new Vector3(0, height, -distance);
        // 摄像机始终面向玩家
        transform.LookAt(target);
    }

    void FixedUpdate()
    {
        // 目标位置为玩家位置加上偏移
        Vector3 targetCamPos = target.position + new Vector3(0, height, -distance);
        // 使用线性插值平滑地移动摄像机到目标位置
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
    //GPT-4是我叠
}
