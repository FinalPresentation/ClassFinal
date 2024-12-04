using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public Transform player; // 玩家角色的Transform
    public float speed = 2f; // 移動速度
    public Vector2 minBounds; // 區域的最小邊界
    public Vector2 maxBounds; // 區域的最大邊界

    private void Update()
    {
        // 計算敵人和玩家之間的方向向量
        Vector2 direction = (player.position - transform.position).normalized;
        if (player.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (player.position.x - transform.position.x >= 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        // 計算新的位置
        Vector2 newPosition = (Vector2)transform.position + direction * speed * Time.deltaTime;

       

        // 移動敵人到新位置
        transform.position = newPosition;
    }

    private void OnDrawGizmosSelected()
    {
        // 在編輯模式下顯示區域邊界
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(minBounds.x, minBounds.y), new Vector2(minBounds.x, maxBounds.y));
        Gizmos.DrawLine(new Vector2(minBounds.x, maxBounds.y), new Vector2(maxBounds.x, maxBounds.y));
        Gizmos.DrawLine(new Vector2(maxBounds.x, maxBounds.y), new Vector2(maxBounds.x, minBounds.y));
        Gizmos.DrawLine(new Vector2(maxBounds.x, minBounds.y), new Vector2(minBounds.x, minBounds.y));
    }
}
