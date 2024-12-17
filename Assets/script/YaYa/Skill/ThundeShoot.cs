using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThundeShoot : MonoBehaviour
{
    public GameObject thunder;
    public GameObject ShowThunder;
    
    public float detectionRadius = 10f;
    
    public float speed = 10f;
   
    private float fireTimer;         // 發射計時器
    private GameObject nearestEnemy; // 最近的敵人
 void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    void Update()
    {
        fireTimer += Time.deltaTime;

        if(nearestEnemy != null )
        {
            Vector3 targetPosition = nearestEnemy.transform.position + new Vector3(0, 2, 0);

            // 如果距離超過小範圍
            if (Vector3.Distance(thunder.transform.position, targetPosition) > 0.1f)
            {
                // 使用插值平滑移動
                thunder.transform.position = Vector3.Lerp(
                    thunder.transform.position,
                    targetPosition,
                    Time.deltaTime * 1.5f
                );
            }
            else
            {
                // 精確定位
                thunder.transform.position = targetPosition;
            }

            // 特效控制邏輯保持不變
            ShowThunder.SetActive(Vector3.Distance(thunder.transform.position, targetPosition) <= 1.5f);
        } 
       
        // 如果找到最近的敵人且可以發射
        if ( fireTimer >= 2.5f|| nearestEnemy==null)
        { FindNearestEnemy();
             // 偵測所有敵人
        
            fireTimer = 0f; // 重置計時器
        }
       
        
    }
    void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> enemiesInRange = new List<GameObject>();
        Debug.Log(enemies.Length);
        nearestEnemy = null;

        // 過濾出範圍內的敵人
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < detectionRadius)
            {
                enemiesInRange.Add(enemy);
            }
           
        }

        // 如果有敵人在範圍內，隨機選擇一個
        if (enemiesInRange.Count > 0)
        {
            int randomIndex = Random.Range(0, enemiesInRange.Count);
            nearestEnemy = enemiesInRange[randomIndex];
        }
        Debug.Log("Enemy:"+enemiesInRange.Count);
    }

}
