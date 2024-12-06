using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;  // 子彈預製體
    public float fireRate = 0.5f;    // 子彈發射頻率
    public float detectionRadius = 10f; // 偵測範圍
    public Transform bulletSpawnPoint; // 子彈生成位置

    private float fireTimer;         // 發射計時器
    private GameObject nearestEnemy; // 最近的敵人

    void Update()
    {
        fireTimer += Time.deltaTime;

        // 偵測所有敵人
        FindNearestEnemy();

        // 如果找到最近的敵人且可以發射
        if (nearestEnemy != null && fireTimer >= fireRate)
        {
            ShootAtEnemy();
            fireTimer = 0f; // 重置計時器
        }
    }

    void FindNearestEnemy()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < detectionRadius && distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
    }
    void ShootAtEnemy()
    {
        // 瞄準最近的敵人
        Vector2 direction = (nearestEnemy.transform.position - transform.position).normalized;

        // 生成子彈
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // 給子彈施加方向和速度
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 10f; // 假設子彈速度為 10
    }
}
