using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedAttack : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10;
    public GameObject particleEffectPrefab;  // 粒子效果的预制体引用
    private Animator animator;

    public float bulletCd;
    public float bulletCdTimer;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            bullet();
        }
        if (bulletCdTimer > 0)
        {
            bulletCdTimer -= Time.deltaTime;
        }
    }


    void bullet()
    {

        if (bulletCdTimer > 0) return;
        else bulletCdTimer = bulletCd;
        // 实例化子弹
        var bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;

        // 实例化粒子效果
        var effect = Instantiate(particleEffectPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);

        animator.SetTrigger("PMC_Range");
    }


}
