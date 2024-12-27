using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : MonoBehaviour
{
    private float HorizontalInput;
    private float VerticalInput;
    public float speed = 10;
    public GameObject SniperShoot;

    private SpriteRenderer sprite;
 
    public float timer;
    public float RecordTime=3;
    public int ChangeColorInt=0;
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        
        StartCoroutine(Aim());
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (ChangeColorInt==0&&timer > RecordTime)
        {
            ChangeColorInt = 1;
            timer = 0;
        }
        if (ChangeColorInt==1&&timer > 0.2f) 
        {
            sprite.color = new Color32(255,0,0,255);
            ChangeColorInt= 2;
            timer = 0;    
        }
        if(ChangeColorInt==2&&timer > 0.2f) 
        {
            sprite.color=new Color32(255,192,0,255);
            ChangeColorInt=1;
            timer = 0;
        }
        HorizontalInput = Input.GetAxis("Horizontal");
        VerticalInput = Input.GetAxis("Vertical");
        transform.Translate(HorizontalInput * speed * Time.deltaTime, VerticalInput * speed * Time.deltaTime, 0);

    }
    IEnumerator Aim()
    {
      yield return new WaitForSeconds(5);
        Instantiate(SniperShoot,this.gameObject.transform.position,Quaternion.identity);
        Destroy(gameObject);
    }
}
