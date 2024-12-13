using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RotateAttack : MonoBehaviour
{
    public main damgage;
    public float RotateBallDamage;
    public EnemyHealth EnemyHealth;
    public float CurrentHealth;
    public float SkillDamage;
    public GameObject PlayerPosition;
    private void Start()
    {
     Rigidbody2D rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            Debug.Log("AAA");
        }
       
            if (collision.tag == "Enemy" && !EnemyHealth.isInvincible)
            {

                StartCoroutine(InvincibilityPeriod());
            }
        
    }
    private IEnumerator InvincibilityPeriod()
    {
        CurrentHealth = FindObjectOfType<EnemyHealth>().health;
        SkillDamage = FindObjectOfType<main>().damage;
        EnemyHealth.isInvincible = true;
        CurrentHealth = CurrentHealth - SkillDamage;
        FindObjectOfType<EnemyHealth>().health = CurrentHealth;

        yield return new WaitForSeconds(0.1f);
        EnemyHealth.isInvincible = false;
    }


}
