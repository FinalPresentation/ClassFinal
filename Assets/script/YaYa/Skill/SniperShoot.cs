using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperShoot : MonoBehaviour
{
    public float FireTime = 15;
    public float RecordTime = 14;
    public GameObject SniperPrefab;
    public Transform PlayerPosition;
    void Update()
    {
        RecordTime += Time.deltaTime;
    if(RecordTime >= FireTime )
        {
            RecordTime = 0;
            Sniper();
            
        }
    }

    public void Sniper()
    {
        Instantiate(SniperPrefab,PlayerPosition.transform.position,Quaternion.identity);
    }
}
