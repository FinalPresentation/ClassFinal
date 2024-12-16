using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu( menuName = "Skills/Test")]
public class BulletData : Skill
{
    public override void ApplyEffect(GameObject player)
    {
        var playerStats = player.GetComponent<main>();
        if (playerStats != null)
        {
        }

    }
}