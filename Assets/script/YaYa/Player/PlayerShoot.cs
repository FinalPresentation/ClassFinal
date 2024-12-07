using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;  // �l�u�w�s��
    public float fireRate = 0.5f;    // �l�u�o�g�W�v
    public float detectionRadius = 10f; // �����d��
    public Transform bulletSpawnPoint; // �l�u�ͦ���m

    private float fireTimer;         // �o�g�p�ɾ�
    private GameObject nearestEnemy; // �̪񪺼ĤH

    void Update()
    {
        fireTimer += Time.deltaTime;

        // �����Ҧ��ĤH
        FindNearestEnemy();

        // �p�G���̪񪺼ĤH�B�i�H�o�g
        if (nearestEnemy != null && fireTimer >= fireRate)
        {
            ShootAtEnemy();
            fireTimer = 0f; // ���m�p�ɾ�
        }
    }

    void FindNearestEnemy()
    {
        float shortestDistance = Mathf.Infinity;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");

        nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < detectionRadius && distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
    }
    void ShootAtEnemy()
    {
        // �˷ǳ̪񪺼ĤH
        Vector2 direction = (nearestEnemy.transform.position - transform.position).normalized;

        // �ͦ��l�u
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);

        // ���l�u�I�[��V�M�t��
        bullet.GetComponent<Rigidbody2D>().velocity = direction * 10f; // ���]�l�u�t�׬� 10
    }
}
