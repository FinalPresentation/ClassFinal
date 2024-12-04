using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    public Transform player; // ���a���⪺Transform
    public float speed = 2f; // ���ʳt��
    public Vector2 minBounds; // �ϰ쪺�̤p���
    public Vector2 maxBounds; // �ϰ쪺�̤j���

    private void Update()
    {
        // �p��ĤH�M���a��������V�V�q
        Vector2 direction = (player.position - transform.position).normalized;
        if (player.position.x - transform.position.x < 0)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (player.position.x - transform.position.x >= 0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        // �p��s����m
        Vector2 newPosition = (Vector2)transform.position + direction * speed * Time.deltaTime;

       

        // ���ʼĤH��s��m
        transform.position = newPosition;
    }

    private void OnDrawGizmosSelected()
    {
        // �b�s��Ҧ��U��ܰϰ����
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(minBounds.x, minBounds.y), new Vector2(minBounds.x, maxBounds.y));
        Gizmos.DrawLine(new Vector2(minBounds.x, maxBounds.y), new Vector2(maxBounds.x, maxBounds.y));
        Gizmos.DrawLine(new Vector2(maxBounds.x, maxBounds.y), new Vector2(maxBounds.x, minBounds.y));
        Gizmos.DrawLine(new Vector2(maxBounds.x, minBounds.y), new Vector2(minBounds.x, minBounds.y));
    }
}
