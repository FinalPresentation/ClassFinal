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
    public bool LifeSteal = false;

    public AudioSource audioSource;  // 音效播放器
    public AudioClip hurtSound;      // 受傷音效


    // ... 其他變數

    private void OnEnable()
    {
        // 訂閱狀態改變事件
        LifeStolen.OnLifeStealStatusChanged += UpdateLifeStealStatus;

        // 檢查並套用當前狀態
        if (LifeStolen.Instance != null)
        {
            LifeSteal = LifeStolen.Instance.isLifeStealActive;
        }
    }

    private void OnDisable()
    {
        // 取消訂閱
        LifeStolen.OnLifeStealStatusChanged -= UpdateLifeStealStatus;
    }

    private void UpdateLifeStealStatus(bool active)
    {
        LifeSteal = active;
    }

   
        private void Start()
        {
            if (audioSource == null)
            {
                audioSource = GetComponent<AudioSource>();
                if (audioSource == null)
                {
                    Debug.LogError("AudioSource not found! Please attach one to this GameObject.");
                }
            }
        }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       if(collision.tag=="bullet"&&isInvincible==false)
        {
            StartCoroutine(InvincibilityPeriod());
            if (LifeSteal == true)
            {
                FindObjectOfType<HitPoint>().hp=FindObjectOfType<HitPoint>().hp+1;
            }
        }
       if(collision.tag=="RotateBall"&&isInvincible == false)
        {
           
            StartCoroutine(InvincibilityPeriod2());
        }
       if (collision.tag == "Bomb"&&isInvincible==false)
        { 
            StartCoroutine(InvincibilityPeriod3());
        }
        if (collision.tag == "Boomerang" && isInvincible == false)
        {
            StartCoroutine(InvincibilityPeriod5());
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Thunder" && isInvincible == false)
        {
            
            StartCoroutine(InvincibilityPeriod4());
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
        PlayHurtSound();
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }
    private IEnumerator InvincibilityPeriod2()
    {
        skilldamage = FindObjectOfType<main>().damage;
        isInvincible = true;
        health = health - skilldamage;
        PlayHurtSound();
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }
    private IEnumerator InvincibilityPeriod3()
    {
        skilldamage = FindObjectOfType<main>().damage*5;
        isInvincible = true;
        health = health - skilldamage;
        PlayHurtSound();
        yield return new WaitForSeconds(1);
        isInvincible = false;
    }
    private IEnumerator InvincibilityPeriod4()
    {
        Debug.Log("AAA");
        skilldamage = FindObjectOfType<main>().damage*0.3f ;
        isInvincible = true;
        health = health - skilldamage;
        PlayHurtSound();
        yield return new WaitForSeconds(0.2f);
        isInvincible = false;
    }
    private IEnumerator InvincibilityPeriod5()
    {
        Debug.Log("AAA");
        skilldamage = FindObjectOfType<main>().damage * 1f;
        isInvincible = true;
        health = health - skilldamage;
        PlayHurtSound();
        yield return new WaitForSeconds(0.5f);
        isInvincible = false;
    }

    private void PlayHurtSound()
    {
        if (audioSource != null && hurtSound != null)
        {
            audioSource.PlayOneShot(hurtSound);
        }
    }
}
