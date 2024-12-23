using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class main : MonoBehaviour
{
    public int level = 1;
    public float Upgrade = 100;
    public float Xp = 0;

    public float damage;
    public SkillUI OpenSkillUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "XP")
        {
            Destroy(collision.gameObject);
            if (level < 36)
            {
                Xp = Xp + 30;
            }
            
        }
    }
    private void Update()
    {
        if(level < 36) // 七個技能5個等級 初始lv.1
        {
            if (Xp >= Upgrade)
            {
                Xp = Xp - Upgrade;
                level++;
                Upgrade = Upgrade * 1.2f;
                Time.timeScale = 0;
                OpenSkillUI.gameObject.SetActive(true);
                OpenSkillUI.ShowSkillChoices();
            }
        }
        else
        {
            Xp = Upgrade - 1;
        }

        

        Debug.Log("Level:"+level+"  Upgrade"+Upgrade+"  Xp"+Xp);
    }
}
