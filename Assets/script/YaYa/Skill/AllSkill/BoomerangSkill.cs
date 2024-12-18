using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Skills/BoomerangSkill")]
public class BoomerangSkill : Skill
{
    public override void ApplyEffect(GameObject player)
    {
        var boomerang = player.GetComponent<BoomerangShoot>();
        if (boomerang != null)
        {
            boomerang.enabled = true;
            Debug.Log("�j�O��!�Ұ�!");

        }
        else
        {
            Debug.Log("�䤣��j�O��");
        }
    }
}

