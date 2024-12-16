using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Skills/BombSkill")]
public class BombSkill : Skill
{
    public override void ApplyEffect(GameObject player)
    {
        var bomb = player.GetComponent<BombShoot>();
        if (bomb != null)
        {
            bomb.enabled = true;
            Debug.Log("¬µ¼u!±Ò°Ê!");

        }
        else
        {
            Debug.Log("§ä¤£¨ì¬µ¼u");
        }
    }
}
