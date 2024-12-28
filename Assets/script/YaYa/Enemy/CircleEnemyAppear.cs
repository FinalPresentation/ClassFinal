using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleEnemyAppear : MonoBehaviour
{
    public GameObject []enemyPrefab; // �Ǫ����w�s��
    public int enemyCount = 8;     // ��P�W���Ǫ��ƶq
    public float spawnRadius = 5f; // ��Υb�|
    public Transform player;       // ���a���⪺ Transform
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
        // �T�O���a����s�b
        if (player == null)
        {
            Debug.LogError("Player Transform is not assigned!");
            return;
        }
        
        for (int i = 0; i < enemyCount; i++)
        {
            // �p��C�өǪ������ס]���� 360 �ס^
            float angle = i * (360f / enemyCount);

            // �N�����ഫ������
            float radian = angle * Mathf.Deg2Rad;

            // �p��Ǫ����ͦ���m
            float x = player.position.x + Mathf.Cos(radian) * spawnRadius;
            float y = player.position.y + Mathf.Sin(radian) * spawnRadius;
            Vector3 spawnPosition = new Vector3(x, y, 0); // ���] Z �b�� 0

            // �ͦ��Ǫ�
            Instantiate(enemyPrefab[Kind], spawnPosition, Quaternion.identity);
        }
        appearTime = Random.Range(15, 25);
        Kind=Random.Range(0,3);
    }
}
