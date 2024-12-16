using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Skills/RotateBall")]
public class RotateBallSkill : Skill
{


    public override void ApplyEffect(GameObject player)
    {
        Transform rotateBallTransform = player.transform.Find("Rotate");

        if (rotateBallTransform != null)
        {
            GameObject rotateBall = rotateBallTransform.gameObject;
            rotateBall.SetActive(true); // ±Ò¥Î RotateBall

        }
        else
        {
            Debug.LogWarning("RotateBall object not found as a child of the player!");

        }
    }
}