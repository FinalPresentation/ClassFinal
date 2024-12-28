using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRush : MonoBehaviour
{
    private GameObject player;
    private Transform PlayerPosition; // 玩家位置
    public float speed = 15f; // 移動速度

    private Vector3 targetPosition; // 目標位置

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        PlayerPosition = player.transform;
        Vector3 direction = (PlayerPosition.position - transform.position).normalized; // 從怪物到玩家的單位方向
        targetPosition = transform.position + direction * Vector3.Distance(transform.position, PlayerPosition.position) * 3;
    }

    private void Update()
    {
        // 移動到目標位置
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // 當到達目標位置時，摧毀物件
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
