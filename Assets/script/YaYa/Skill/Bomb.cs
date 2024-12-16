using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{

    public float slowDownRadius = 5f; // �Z�����}�l��t
    public float explosionRadius = 1f; // �Z�����z��
    public float slowDownRate = 0.9f; // ��t���
    public float explosionDelay = 0.5f; // �z������
    public GameObject explosionEffect; // �z���ĪG

    public float explsionTime = 3f;
  
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
        
        // �p�⬵�u�P�ؼЪ��Z��
     //   float distanceToEnemy = Vector2.Distance(transform.position, targetEnemy.transform.position);
        explsionTime -= Time.deltaTime;
        // �}�l��t
        if (explsionTime<=2)
        {
            rb.velocity *= slowDownRate;
        }

        // �z������
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
        
        // ����R�����u
        yield return new WaitForSeconds(explosionDelay);
        Instantiate(explosionEffect,gameObject.transform.position,Quaternion.identity);
        Destroy(this.gameObject);

       
    }
}
