using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Skills/IncreaseAttack")]
public class IncreaseAttack : Skill
{
    public float attackBoost = 3f;

    public override void ApplyEffect(GameObject player)
    {
        var playerStats = player.GetComponent<main>();
        if (playerStats != null)
        {
            playerStats.damage += attackBoost;
            Debug.Log($"Increased attack power by {attackBoost}");
        }

    }

}
