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
            Debug.Log("���u!�Ұ�!");

        }
        else
        {
            Debug.Log("�䤣�쬵�u");
        }
    }
}
