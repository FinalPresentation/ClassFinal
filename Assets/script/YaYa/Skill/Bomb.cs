using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float slowDownRadius = 5f; // 距離內開始減速
    public float explosionRadius = 1f; // 距離內爆炸
    public float slowDownRate = 0.9f; // 減速比例
    public float explosionDelay = 0.5f; // 爆炸延遲
    public GameObject explosionEffect; // 爆炸效果

    public float explsionTime = 3f;
  
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        
        // 計算炸彈與目標的距離
     //   float distanceToEnemy = Vector2.Distance(transform.position, targetEnemy.transform.position);
        explsionTime -= Time.deltaTime;
        // 開始減速
        if (explsionTime<=2)
        {
            rb.velocity *= slowDownRate;
        }

        // 爆炸條件
        if (explsionTime<=0)
        {
            StartCoroutine(Explode());
         
        }
    }

    public void SetTarget(GameObject enemy)
    {
      //  targetEnemy = enemy;
        
    }

    IEnumerator Explode()
    {
        
        // 延遲刪除炸彈
        yield return new WaitForSeconds(explosionDelay);
        Instantiate(explosionEffect,gameObject.transform.position,Quaternion.identity);
        Destroy(this.gameObject);

       
    }
}
