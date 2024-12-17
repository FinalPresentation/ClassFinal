using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Skills/ThunderSkill")]
public class ThunderSkill : Skill
{
    public override void ApplyEffect(GameObject player)
    {
        var thunder = player.GetComponent<ThundeShoot>();
        if (thunder!= null)
        {
            thunder.enabled = true;
            Debug.Log("打雷!啟動!");

        }
        else
        {
            Debug.Log("找不到雲朵");
        }
    }
}

