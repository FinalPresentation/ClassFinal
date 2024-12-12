using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health=5;
    public float damage;
    private bool isInvincible = false;
    public float invincibilityDuration = 0.1f;
    public GameObject XP;

    private void Start()
    {
      
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag=="bullet")
        {
            StartCoroutine(InvincibilityPeriod());
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
}
