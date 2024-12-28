using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockOfBirds : MonoBehaviour
{

    public GameObject enemyPrefab;  // �Ǫ��w�s��
    public float spawnRange = 5f;   // �Z���۾����d��
    public float spawnTime = 15f; // �ͦ����j
    public float RecordTime = 0;
    public float spawnTimer = 0;
    private Camera mainCamera;
    public bool AppearEnemy = false;

    void Start()
    {
        mainCamera = Camera.main;

    }
    private void Update()
    {
        RecordTime += Time.deltaTime;
        spawnTimer += Time.deltaTime;


        if (RecordTime >= 120)
        {
            AppearEnemy = true;
        }
      
        
        if (spawnTimer >= spawnTime&&AppearEnemy)
        {
            SpawnEnemy();
            spawnTimer = 0f; // ���m�p�ɾ�
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
