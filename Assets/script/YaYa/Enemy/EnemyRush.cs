using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRush : MonoBehaviour
{
    private GameObject player;
    private Transform PlayerPosition; // ���a��m
    public float speed = 15f; // ���ʳt��

    private Vector3 targetPosition; // �ؼЦ�m

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        PlayerPosition = player.transform;
        Vector3 direction = (PlayerPosition.position - transform.position).normalized; // �q�Ǫ��쪱�a������V
        targetPosition = transform.position + direction * Vector3.Distance(transform.position, PlayerPosition.position) * 3;
    }

    private void Update()
    {
        // ���ʨ�ؼЦ�m
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        // ���F�ؼЦ�m�ɡA�R������
        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            Destroy(gameObject);
        }
    }
}
