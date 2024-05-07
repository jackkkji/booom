using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Spawn_Enemy : MonoBehaviour
{
    public GameObject theEnemy;
    public GameObject player;  // 玩家对象
    public int EnemyCount;

    public void Start()
    {
       
    }

    public void SpawnEnemies()
    {
            while (EnemyCount < 20)
            {
                // 获取玩家当前位置
                Vector3 playerPosition = player.transform.position;

                // 在玩家附近生成敌人，可以调整范围大小来控制距离
                int xPos = (int)playerPosition.x + Random.Range(-5, 6);
                int zPos = (int)playerPosition.z + Random.Range(-5, 6);

                Instantiate(theEnemy, new Vector3(xPos, -4, zPos), Quaternion.identity);
                EnemyCount += 1;
            }
    }
}
