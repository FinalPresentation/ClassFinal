using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public HitPoint playerHealth;
    public Image totalhealthbar;
    public Image Currenthealthbar;

    private void Start()
    {

        totalhealthbar.fillAmount = playerHealth.hp ;

    }
    private void Update()
    {
        Currenthealthbar.fillAmount = playerHealth.hp /100;
        Debug.Log(playerHealth.hp);
    }

}
