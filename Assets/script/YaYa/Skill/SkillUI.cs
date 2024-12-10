using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SkillUI : MonoBehaviour
{
    public List<Skill> allSkills; // 所有技能
    public List<GameObject> skillButtons; // 三個技能按鈕對應的 UI
    private SkillManager skillManager;

    private void Awake()
    {
        skillManager = FindObjectOfType<SkillManager>();
    }

    public void ShowSkillChoices()
    {
        // 隨機挑選三個技能
        List<Skill> chosenSkills = new List<Skill>();
        while (chosenSkills.Count < 3)
        {
            Skill randomSkill = allSkills[Random.Range(0, allSkills.Count)];
            if (!chosenSkills.Contains(randomSkill)) // 確保不重複
            {
                chosenSkills.Add(randomSkill);
            }
        }

        // 更新按鈕內容並綁定點擊事件
        for (int i = 0; i < skillButtons.Count; i++)
        {
            var button = skillButtons[i];
            var skill = chosenSkills[i];

            // 設定圖示與名稱
            button.GetComponent<Image>().sprite = skill.icon;
            button.GetComponentInChildren<TextMeshProUGUI>().text = skill.skillName;

            // 清除之前的點擊事件，綁定新事件
            Button btnComponent = button.GetComponent<Button>();
            btnComponent.onClick.RemoveAllListeners();
            btnComponent.onClick.AddListener(() => SelectSkill(skill));
        }
    }

    private void SelectSkill(Skill chosenSkill)
    {
        // 添加技能到玩家
        skillManager.AddSkill(chosenSkill);

        // 關閉技能選擇 UI 並繼續遊戲
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
