using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    private List<Skill> acquiredSkills = new List<Skill>();

    public void AddSkill(Skill skill)
    {
        acquiredSkills.Add(skill);
        skill.ApplyEffect(gameObject); // 立即執行技能效果
        Debug.Log($"Skill {skill.skillName} acquired!");
    }

    public List<Skill> GetAcquiredSkills()
    {
        return acquiredSkills;
    }
}
