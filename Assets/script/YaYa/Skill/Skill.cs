using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSkill", menuName = "skill")] 
public abstract class Skill : ScriptableObject 
{
    public abstract void ApplyEffect(GameObject player);
    public string skillName;
    public string description;
    public Sprite icon;
    
    
   

}
[CreateAssetMenu(menuName = "Skills/IncreaseAttack")]
public class IncreaseAttack :Skill
{
    public float attackBoost = 10f;

    public override void ApplyEffect(GameObject player)
    {
        var playerStats = player.GetComponent<Bullet>();
        if (playerStats != null)
        {
            playerStats.damage += attackBoost;
            Debug.Log($"Increased attack power by {attackBoost}");
        }
    }
    
}

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



