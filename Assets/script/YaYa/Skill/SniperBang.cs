using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBang : MonoBehaviour
{

    public float timer=0;
   
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.1f)
        {
            GetComponent<CircleCollider2D>().enabled = false;
        }

        if (timer > 1f)
        {
            Destroy(gameObject);
        }
    }        
   
}
