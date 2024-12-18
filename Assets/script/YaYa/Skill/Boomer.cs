using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomer : MonoBehaviour
{

    private GameObject player;      // 玩家
    private GameObject target;      // 目標
    private bool meetTarget = false; // 是否到達目標
    public float speed = 10f;       // 飛行速度
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
            // 朝目標移動
            transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime+playermove.speed*Time.deltaTime);

            // 如果到達目標
            if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
            {
                meetTarget = true;
              
            }
        }
        else
        {
            // 返回玩家
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime + playermove.speed * Time.deltaTime);

            // 如果返回到玩家
            if (Vector3.Distance(transform.position, player.transform.position) < 0.1f)
            {
                Destroy(gameObject); // 銷毀迴力鏢
            }
        }
    }

  
}
