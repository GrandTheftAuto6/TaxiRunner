using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class Progress : MonoBehaviour
{
    public static Progress Instance;
    public int moneyAmount;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }

        YandexPlugin._instance.LoadData();
    }
}
