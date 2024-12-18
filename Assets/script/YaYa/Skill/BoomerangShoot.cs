using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangShoot : MonoBehaviour
{


    public GameObject boomerPrefab;     // �j�O�𪺹w�s��
    public float detectionRadius = 10f; // �����d��
    public float fireRate = 1f;         // �o�g���j
    private float fireTimer;            // �o�g�p�ɾ�
    public GameObject player;           // ���a

    private void Update()
    {
        fireTimer += Time.deltaTime;

        // �w���o�g�j�O��
        if (fireTimer >= fireRate)
        {
            fireTimer = 0f;
            ShootBoomerang();
        }
    }

    private void ShootBoomerang()
    {
        // ���@�ӥؼмĤH
        GameObject target = FindRandomEnemy();
        if (target != null)
        {
            // �ͦ��j�O��ó]�m�ؼ�
            GameObject boomer = Instantiate(boomerPrefab, player.transform.position, Quaternion.identity);
            Boomer boomerangScript = boomer.GetComponent<Boomer>();
            if (boomerangScript != null)
            {
                boomerangScript.Initialize(player, target);
            }
        }
    }

    private GameObject FindRandomEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> enemiesInRange = new List<GameObject>();

        // �z��d�򤺪��ĤH
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < detectionRadius)
            {
                enemiesInRange.Add(enemy);
            }
        }

        // �p�G���ĤH�A�H����ܤ@��
        if (enemiesInRange.Count > 0)
        {
            int randomIndex = Random.Range(0, enemiesInRange.Count);
            return enemiesInRange[randomIndex];
        }

        return null; // �S���ĤH�b�d��
    }
}
