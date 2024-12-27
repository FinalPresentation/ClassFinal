using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyAppear : MonoBehaviour
{
    public GameObject[] enemyPrefab;  // 怪物預製體
    public float spawnRange = 5f;   // 距離相機的範圍
    public float spawnTime = 2f; // 生成間隔
    public float RecordTime = 0;
    public float spawnTimer = 0;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;

    }
    private void Update()
    {
        RecordTime += Time.deltaTime;



        if (RecordTime >= 80)

            spawnTime = 0.1f;
        else if (RecordTime >= 60)
        {

            spawnTime = 0.25f;
        }
        else if (RecordTime >= 40)
        {

            spawnTime = 0.45f;
        }
        else if (RecordTime >= 20)
        {
            spawnTime = 0.6f;
        }
        spawnTimer += Time.deltaTime;
        if (spawnTimer >= spawnTime)
        {
            SpawnEnemy();
            spawnTimer = 0f; // 重置計時器
        }
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
        int randomrate = Random.Range(0, 101);
        if (randomrate <= 50)
        {
            Instantiate(enemyPrefab[0], spawnPosition, Quaternion.identity);
        }
        else if (randomrate > 50 && randomrate <= 80)
        {
            Instantiate(enemyPrefab[1], spawnPosition, Quaternion.identity);

        }
        else if (randomrate > 80 && randomrate <= 100)
        {
            Instantiate(enemyPrefab[2], spawnPosition, Quaternion.identity);
        }
        Debug.Log("randomrate" + randomrate);
    }
}
