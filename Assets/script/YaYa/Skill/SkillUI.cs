using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SkillUI : MonoBehaviour
{
    public List<Skill> allSkills; // �Ҧ��ޯ�
    public List<GameObject> skillButtons; // �T�ӧޯ���s������ UI
    private SkillManager skillManager;

    private void Awake()
    {
        skillManager = FindObjectOfType<SkillManager>();
    }

    public void ShowSkillChoices()
    {
        // �H���D��T�ӧޯ�
        List<Skill> chosenSkills = new List<Skill>();
        while (chosenSkills.Count < 3)
        {
            Skill randomSkill = allSkills[Random.Range(0, allSkills.Count)];
            if (!chosenSkills.Contains(randomSkill)) // �T�O������
            {
                chosenSkills.Add(randomSkill);
            }
        }

        // ��s���s���e�øj�w�I���ƥ�
        for (int i = 0; i < skillButtons.Count; i++)
        {
            var button = skillButtons[i];
            var skill = chosenSkills[i];

            // �]�w�ϥܻP�W��
            button.GetComponent<Image>().sprite = skill.icon;
            button.GetComponentInChildren<TextMeshProUGUI>().text = skill.skillName;

            // �M�����e���I���ƥ�A�j�w�s�ƥ�
            Button btnComponent = button.GetComponent<Button>();
            btnComponent.onClick.RemoveAllListeners();
            btnComponent.onClick.AddListener(() => SelectSkill(skill));
        }
    }

    private void SelectSkill(Skill chosenSkill)
    {
        // �K�[�ޯ�쪱�a
        skillManager.AddSkill(chosenSkill);

        // �����ޯ��� UI ���~��C��
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
