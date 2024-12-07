using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 1;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            
            Destroy(gameObject);          // ¾P·´¤l¼u
        }
    }

    void Update()
    {
        // ¾P·´¶W¥X½d³òªº¤l¼u
        if (Vector2.Distance(transform.position, Vector2.zero) > 50f)
        {
            Destroy(gameObject);
        }
    }
}
