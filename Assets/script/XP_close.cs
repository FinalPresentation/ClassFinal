using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_close : MonoBehaviour
{
    private GameObject player;
    private Transform playertransform;

    public float speed = 6f; // 移動速度
    public Vector2 minBounds; // 區域的最小邊界
    public Vector2 maxBounds; // 區域的最大邊界
    public float triggerDistance = 3f; // 觸發追蹤距離

    public bool closed = false; //判斷追蹤觸發 
    private void Start()
    {
        speed = 6f;
        triggerDistance = 3f;
        player = GameObject.FindWithTag("Player");
        playertransform = player.transform;
    }
    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playertransform.position);

        if(distanceToPlayer <= triggerDistance)
        {
            closed = true;
        }
        if (closed){
            // 計算經驗值和玩家之間的方向向量
            Vector2 direction = (playertransform.position - transform.position).normalized;
            if (playertransform.position.x - transform.position.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (playertransform.position.x - transform.position.x >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 10, 0);
            }
            // 計算新的位置
            Vector2 newPosition = (Vector2)transform.position + direction * speed * Time.deltaTime;



            // 移動經驗值到新位置
            transform.position = newPosition;
        }
        
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
