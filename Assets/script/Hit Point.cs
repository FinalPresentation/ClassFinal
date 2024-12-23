using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPoint : MonoBehaviour
{
    public float maxHP = 100;
    public float hp;
    private bool isInvincible=false;
    public float invincibilityDuration = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        hp = maxHP;
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0)
        {
            Debug.Log("Game Over!");
            Time.timeScale = 0;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (isInvincible==false&&collision.CompareTag("Enemy"))
        {
           StartCoroutine( InvincibilityPeriod());

        }
    }
    private IEnumerator InvincibilityPeriod()
    {
        isInvincible = true;
        hp -= 10;
        yield return new WaitForSeconds(invincibilityDuration);
        isInvincible = false;
    }
}
