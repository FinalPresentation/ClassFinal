using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemyAppear : MonoBehaviour
{
    public GameObject []enemyPrefab; // 怪物的預製體
    public int enemyCount = 8;     // 圓周上的怪物數量
    public float spawnRadius = 5f; // 圓形半徑
    public Transform player;       // 玩家角色的 Transform
    public float timer = 0;
    public float appearTime=0f;
   public bool StartAppear= false;
    public int Kind = 0;

    private void Update()
    {timer += Time.deltaTime;
        if (timer >= 80f)
        {
            timer = 0;
            StartAppear = true;
        }
        if (timer > appearTime&&StartAppear==true)
        {
            SpawnEnemiesAround();
            timer = 0;
        }
        
    }
    void SpawnEnemiesAround()
    {
        // 確保玩家物件存在
        if (player == null)
        {
            Debug.LogError("Player Transform is not assigned!");
            return;
        }
        
        for (int i = 0; i < enemyCount; i++)
        {
            // 計算每個怪物的角度（均分 360 度）
            float angle = i * (360f / enemyCount);

            // 將角度轉換為弧度
            float radian = angle * Mathf.Deg2Rad;

            // 計算怪物的生成位置
            float x = player.position.x + Mathf.Cos(radian) * spawnRadius;
            float y = player.position.y + Mathf.Sin(radian) * spawnRadius;
            Vector3 spawnPosition = new Vector3(x, y, 0); // 假設 Z 軸為 0

            // 生成怪物
            Instantiate(enemyPrefab[Kind], spawnPosition, Quaternion.identity);
        }
        appearTime = Random.Range(15, 25);
        Kind=Random.Range(0,3);
    }
}
