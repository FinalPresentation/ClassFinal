using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLevel : MonoBehaviour
{
    public main PlayerXp;
    public Image MaxXp;
    public Image CurrentXp;
    

    public float XP;
    private void Start()
    {
        MaxXp.fillAmount= PlayerXp.Upgrade;
        
    }
    private void Update()
    {XP = PlayerXp.Upgrade;
        CurrentXp.fillAmount = PlayerXp.Xp/XP;
    }
}
