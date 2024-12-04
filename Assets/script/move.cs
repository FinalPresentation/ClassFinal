using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    private float HorizontalInput;
    private float VerticalInput;
    public float speed = 10;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        transform.Translate(HorizontalInput * speed * Time.deltaTime, VerticalInput * speed * Time.deltaTime, 0);
    }
}
