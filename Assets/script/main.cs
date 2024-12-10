using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class main : MonoBehaviour
{
    public int level = 1;
    public float Upgrade = 100;
    public float Xp = 0;
    public SkillUI OpenSkillUI;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "XP")
        {
            Destroy(collision.gameObject);
            Xp = Xp + 30;
        }
    }
    private void Update()
    {
        if (Xp>=Upgrade)
        {
            Xp = Xp-Upgrade;
            level++;
            Upgrade = Upgrade * 1.2f;
            Time.timeScale = 0;
            OpenSkillUI.ShowSkillChoices();
            

        }
        Debug.Log("Level:"+level+"  Upgrade"+Upgrade+"  Xp"+Xp);
    }
}
