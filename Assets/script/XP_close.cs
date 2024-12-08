using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XP_close : MonoBehaviour
{
    private GameObject player;
    private Transform playertransform;

    public float speed = 6f; // ���ʳt��
    public Vector2 minBounds; // �ϰ쪺�̤p���
    public Vector2 maxBounds; // �ϰ쪺�̤j���
    public float triggerDistance = 3f; // Ĳ�o�l�ܶZ��

    public bool closed = false; //�P�_�l��Ĳ�o 
    private void Start()
    {
        speed = 6f;
        triggerDistance = 3f;
        player = GameObject.FindWithTag("Player");
        playertransform = player.transform;
    }
    private void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, playertransform.position);

        if(distanceToPlayer <= triggerDistance)
        {
            closed = true;
        }
        if (closed){
            // �p��g��ȩM���a��������V�V�q
            Vector2 direction = (playertransform.position - transform.position).normalized;
            if (playertransform.position.x - transform.position.x < 0)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }
            if (playertransform.position.x - transform.position.x >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 10, 0);
            }
            // �p��s����m
            Vector2 newPosition = (Vector2)transform.position + direction * speed * Time.deltaTime;



            // ���ʸg��Ȩ�s��m
            transform.position = newPosition;
        }
        
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
