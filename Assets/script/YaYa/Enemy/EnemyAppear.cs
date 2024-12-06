using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAppear : MonoBehaviour
{
    public GameObject enemyPrefab;  // �Ǫ��w�s��
    public float spawnRange = 5f;   // �Z���۾����d��
    public float spawnTime = 2f; // �ͦ����j

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
            case 0: // �W
                spawnPosition = new Vector2(Random.Range(minX, maxX), cameraTopRight.y + spawnRange);
                break;
            case 1: // �U
                spawnPosition = new Vector2(Random.Range(minX, maxX), cameraBottomLeft.y - spawnRange);
                break;
            case 2: // ��
                spawnPosition = new Vector2(cameraBottomLeft.x - spawnRange, Random.Range(minY, maxY));
                break;
            case 3: // �k
                spawnPosition = new Vector2(cameraTopRight.x + spawnRange, Random.Range(minY, maxY));
                break;
        }

       
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}
