using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public main damage;
    public float BulletDamage=3;
    public void Start()
    {
      
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
             
            Destroy(gameObject);          // �P���l�u
        }
    }

    void Update()
    {BulletDamage= FindObjectOfType<main>().damage ;
        // �P���W�X�d�򪺤l�u
        if (Vector2.Distance(transform.position, Vector2.zero) > 50f)
        {
            Destroy(gameObject);
        }
    }
}
