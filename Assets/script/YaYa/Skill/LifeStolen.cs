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

    // 定義事件
    public static event System.Action<bool> OnLifeStealStatusChanged;

    private void Awake()
    {
        // 單例模式設置
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
        // 通知所有訂閱者
        OnLifeStealStatusChanged?.Invoke(active);
    }
}
