using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomer : MonoBehaviour
{

    private GameObject player;      // ���a
    private GameObject target;      // �ؼ�
    private bool meetTarget = false; // �O�_��F�ؼ�
    public float speed = 10f;       // ����t��
    public move playermove;
    public void Start()
    {
       playermove= FindObjectOfType<move>();
    }
    public void Initialize(GameObject player, GameObject target)
    {
        this.player = player;
        this.target = target;
    }

    private void Update()
    {transform.Rotate(0,0,5);
        if (!meetTarget && target != null)
        {
            // �¥ؼв���
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime+playermove.speed*Time.deltaTime);

            // �p�G��F�ؼ�
            if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
            {
                meetTarget = true;
              
            }
        }
        else
        {
            // ��^���a
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime + playermove.speed * Time.deltaTime);

            // �p�G��^�쪱�a
            if (Vector3.Distance(transform.position, player.transform.position) < 0.1f)
            {
                Destroy(gameObject); // �P���j�O��
            }
        }
    }

  
}
