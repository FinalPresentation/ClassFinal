using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Skills/SniperSkill")]
public class SniperSkill : Skill
{
    public override void ApplyEffect(GameObject player)
    {
        var bomb = player.GetComponent<SniperShoot>();
        if (bomb != null)
        {
            bomb.enabled = true;
            Debug.Log("GG!�Ұ�!");

        }
        else
        {
            Debug.Log("�䤣��GG");
        }
    }
}

