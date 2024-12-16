using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEffect : MonoBehaviour
{
    public float expolsionTime = 0.5f;

  
    private void Update()
    {
        expolsionTime -= Time.deltaTime;
        if(expolsionTime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
