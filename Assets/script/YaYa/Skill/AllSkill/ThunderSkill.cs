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
            Debug.Log("���p!�Ұ�!");

        }
        else
        {
            Debug.Log("�䤣�춳��");
        }
    }
}

