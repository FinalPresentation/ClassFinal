using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LifeStolen : MonoBehaviour
{
    private static LifeStolen instance;
    public static LifeStolen Instance
    {
        get { return instance; }
    }

    public bool isLifeStealActive = false;
    public float remainingDuration = 100f;

    // �w�q�ƥ�
    public static event System.Action<bool> OnLifeStealStatusChanged;

    private void Awake()
    {
        // ��ҼҦ��]�m
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

   

    public void SetLifeStealStatus(bool active, float duration)
    {
        isLifeStealActive = active;
        remainingDuration = duration;
        // �q���Ҧ��q�\��
        OnLifeStealStatusChanged?.Invoke(active);
    }
}
