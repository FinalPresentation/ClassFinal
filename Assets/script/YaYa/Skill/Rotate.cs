using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject RotateTarget;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        RotateTarget.transform.position=transform.position;
    }
}
