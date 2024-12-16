using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/IncreaseSpeed")]
public class IncreaseSpeed : Skill
{
    public float speedBoost = 2f;

    public override void ApplyEffect(GameObject player)
    {
        var playerStats = player.GetComponent<move>();
        if (playerStats != null)
        {
            playerStats.speed += speedBoost;
            Debug.Log($"Increased move speed by {speedBoost}");
        }
    }
}
