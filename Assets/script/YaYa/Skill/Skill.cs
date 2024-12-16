using JetBrains.Annotations;
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




