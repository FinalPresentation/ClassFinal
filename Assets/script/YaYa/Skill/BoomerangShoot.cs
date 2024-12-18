using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangShoot : MonoBehaviour
{


    public GameObject boomerPrefab;     // 迴力鏢的預製體
    public float detectionRadius = 10f; // 偵測範圍
    public float fireRate = 1f;         // 發射間隔
    private float fireTimer;            // 發射計時器
    public GameObject player;           // 玩家

    private void Update()
    {
        fireTimer += Time.deltaTime;

        // 定期發射迴力鏢
        if (fireTimer >= fireRate)
        {
            fireTimer = 0f;
            ShootBoomerang();
        }
    }

    private void ShootBoomerang()
    {
        // 找到一個目標敵人
        GameObject target = FindRandomEnemy();
        if (target != null)
        {
            // 生成迴力鏢並設置目標
            GameObject boomer = Instantiate(boomerPrefab, player.transform.position, Quaternion.identity);
            Boomer boomerangScript = boomer.GetComponent<Boomer>();
            if (boomerangScript != null)
            {
                boomerangScript.Initialize(player, target);
            }
        }
    }

    private GameObject FindRandomEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> enemiesInRange = new List<GameObject>();

        // 篩選範圍內的敵人
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < detectionRadius)
            {
                enemiesInRange.Add(enemy);
            }
        }

        // 如果有敵人，隨機選擇一個
        if (enemiesInRange.Count > 0)
        {
            int randomIndex = Random.Range(0, enemiesInRange.Count);
            return enemiesInRange[randomIndex];
        }

        return null; // 沒有敵人在範圍內
    }
}
