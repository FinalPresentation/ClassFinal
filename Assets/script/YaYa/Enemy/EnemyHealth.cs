using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health=5;
    public float damage;
    public bool isInvincible = false;
    public float invincibilityDuration = 0.1f;
    public GameObject XP;
    public float skilldamage;

    private void Start()
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag=="bullet"&&isInvincible==false)
        {
            StartCoroutine(InvincibilityPeriod());
        }
       if(collision.tag=="RotateBall"&&isInvincible == false)
        {
            Debug.Log("AAA");
            StartCoroutine(InvincibilityPeriod2());
        }
    }
    private void Update()
    { damage =FindObjectOfType<Bullet>().BulletDamage; 
        if (health <= 0)
        {
            Instantiate(XP,transform.position,transform.rotation);
            Destroy(this.gameObject);
        }
    }
    private IEnumerator InvincibilityPeriod()
    {
        isInvincible = true;
         health=health-damage;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }
    private IEnumerator InvincibilityPeriod2()
    {
        skilldamage = FindObjectOfType<main>().damage;
        isInvincible = true;
        health = health - skilldamage;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }
}
