using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SkillUI : MonoBehaviour
{
    public List<Skill> allSkills; // 所有技能
    public List<GameObject> skillButtons; // 三個技能按鈕對應的 UI
    public SkillManager skillManager;
    public Dictionary<string, int> skillDictionary;
    public List<Skill> chosenSkills = new List<Skill>(); // 隨機挑選技能List

    private void Awake()
    {
        skillManager = FindObjectOfType<SkillManager>();
        skillDictionary = new Dictionary<string, int>();
    }

    public void ShowSkillChoices()
    {
        if (allSkills == null || allSkills.Count == 0)
        {
            Debug.LogError("Skill list is empty or not initialized!");
            return;
        }

        // 隨機挑選技能
        int attempts = 0;
        chosenSkills.Clear();
        if (allSkills.Count > 2 ) {
            while (chosenSkills.Count < 3 && attempts < 100)
            {
                Skill randomSkill = allSkills[Random.Range(0, allSkills.Count)];
                if (!chosenSkills.Contains(randomSkill))
                {
                    chosenSkills.Add(randomSkill);
                }
                attempts++;
            }
        }
        else if (allSkills.Count == 2)
        {
            
            chosenSkills.Add(allSkills[0]);
            chosenSkills.Add(allSkills[1]);
        }
        else if (allSkills.Count == 1)
        {
            chosenSkills.Add(allSkills[0]);
        }
        
        if (attempts >= 100)
        {
            Debug.LogError("Failed to select unique skills within reasonable attempts.");
            return;
        }

        // 更新按鈕
        for (int i = 0; i < skillButtons.Count; i++)
        {
            var button = skillButtons[i];
            if (button == null)
            {
                Debug.LogError($"Button {i} is not assigned!");
                continue;
            }

            var skill = chosenSkills[i];

            var image = button.GetComponent<Image>();
            if (image != null) image.sprite = skill.icon;

            var text = button.GetComponentInChildren<TextMeshProUGUI>();
            if (text != null) text.text = skill.skillName;

            var btnComponent = button.GetComponent<Button>();
            if (btnComponent != null)
            {
                btnComponent.onClick.RemoveAllListeners();
                btnComponent.onClick.AddListener(() => SelectSkill(skill));
            }
        }

        gameObject.SetActive(true);
        Debug.Log("Skill choices displayed.");
    }

    private void SelectSkill(Skill chosenSkill)
    {
        // 添加技能到玩家
        chosenSkill.ApplyEffect(GameObject.FindGameObjectWithTag("Player")); // 傳入玩家角色
        if (skillDictionary.ContainsKey(chosenSkill.skillName))
        {
            // 如果物品已存在，增加數量
            skillDictionary[chosenSkill.skillName] += 1;
            Debug.Log("LevelUp: " + chosenSkill.skillName + skillDictionary[chosenSkill.skillName]);
            if (skillDictionary[chosenSkill.skillName] >= 5)
            {
                allSkills.Remove(chosenSkill);
                Debug.Log("ab" + allSkills.Count);
                for (int i = 0; i < allSkills.Count; i++)
                {
                    Debug.Log("ab" + allSkills[i]);
                }
            }
        }
        else
        {
            // 如果物品不存在，新增物品
            skillDictionary[chosenSkill.skillName] = 1;
            Debug.Log("Getskill" + chosenSkill.skillName + skillDictionary[chosenSkill.skillName]);
        }
        // 關閉技能選擇 UI 並繼續遊戲
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
