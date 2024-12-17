using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ThundeShoot : MonoBehaviour
{
    public GameObject thunder;
    public GameObject ShowThunder;
    
    public float detectionRadius = 10f;
    
    public float speed = 10f;
   
    private float fireTimer;         // �o�g�p�ɾ�
    private GameObject nearestEnemy; // �̪񪺼ĤH
 void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, detectionRadius);
        }
    void Update()
    {
        fireTimer += Time.deltaTime;

        if(nearestEnemy != null )
        {
            Vector3 targetPosition = nearestEnemy.transform.position + new Vector3(0, 2, 0);

            // �p�G�Z���W�L�p�d��
            if (Vector3.Distance(thunder.transform.position, targetPosition) > 0.1f)
            {
                // �ϥδ��ȥ��Ʋ���
                thunder.transform.position = Vector3.Lerp(
                    thunder.transform.position,
                    targetPosition,
                    Time.deltaTime * 1.5f
                );
            }
            else
            {
                // ��T�w��
                thunder.transform.position = targetPosition;
            }

            // �S�ı����޿�O������
            ShowThunder.SetActive(Vector3.Distance(thunder.transform.position, targetPosition) <= 1.5f);
        } 
       
        // �p�G���̪񪺼ĤH�B�i�H�o�g
        if ( fireTimer >= 2.5f|| nearestEnemy==null)
        { FindNearestEnemy();
             // �����Ҧ��ĤH
        
            fireTimer = 0f; // ���m�p�ɾ�
        }
       
        
    }
    void FindNearestEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<GameObject> enemiesInRange = new List<GameObject>();
        Debug.Log(enemies.Length);
        nearestEnemy = null;

        // �L�o�X�d�򤺪��ĤH
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);

            if (distanceToEnemy < detectionRadius)
            {
                enemiesInRange.Add(enemy);
            }
           
        }

        // �p�G���ĤH�b�d�򤺡A�H����ܤ@��
        if (enemiesInRange.Count > 0)
        {
            int randomIndex = Random.Range(0, enemiesInRange.Count);
            nearestEnemy = enemiesInRange[randomIndex];
        }
        Debug.Log("Enemy:"+enemiesInRange.Count);
    }

}
