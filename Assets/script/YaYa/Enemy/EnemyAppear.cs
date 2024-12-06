using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAppear : MonoBehaviour
{
    public GameObject enemyPrefab;  // 怪物預製體
    public float spawnRange = 5f;   // 距離相機的範圍
    public float spawnTime = 2f; // 生成間隔

    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
        InvokeRepeating("SpawnEnemy", 0f, spawnTime);
    }

    void SpawnEnemy()
    {
       
        Vector3 cameraBottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 cameraTopRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        
        float minX = cameraBottomLeft.x - spawnRange;
        float maxX = cameraTopRight.x + spawnRange;
        float minY = cameraBottomLeft.y - spawnRange;
        float maxY = cameraTopRight.y + spawnRange;

       
        int edge = Random.Range(0, 4);  
        Vector2 spawnPosition = Vector2.zero;

        switch (edge)
        {
            case 0: // 上
                spawnPosition = new Vector2(Random.Range(minX, maxX), cameraTopRight.y + spawnRange);
                break;
            case 1: // 下
                spawnPosition = new Vector2(Random.Range(minX, maxX), cameraBottomLeft.y - spawnRange);
                break;
            case 2: // 左
                spawnPosition = new Vector2(cameraBottomLeft.x - spawnRange, Random.Range(minY, maxY));
                break;
            case 3: // 右
                spawnPosition = new Vector2(cameraTopRight.x + spawnRange, Random.Range(minY, maxY));
                break;
        }

       
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
