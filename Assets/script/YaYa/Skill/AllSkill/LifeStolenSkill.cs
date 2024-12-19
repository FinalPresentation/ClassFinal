using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
[CreateAssetMenu(menuName = "Skills/LifeStolenSkill")]
public class LifeStolenSkill : Skill
{
    [SerializeField] private float duration = 10f;

    public override void ApplyEffect(GameObject player)
    {
        var manager = FindObjectOfType<LifeStolen>();
        if (manager == null)
        {
            var go = new GameObject("LifeStealManager");
            manager = go.AddComponent<LifeStolen>();
        }

        // ±Ò°Ê§l¦å®ÄªG
        manager.SetLifeStealStatus(true, duration);
    }
}
