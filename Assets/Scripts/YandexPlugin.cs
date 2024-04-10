using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class YandexPlugin : MonoBehaviour
{
    public static YandexPlugin _instance;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        { 
            _instance = this;
        }
    }


    private int passengersBestScore;
    public int moneyAmount;

    private void Start()
    {
        LoadData();
    }

    public void AddNewLiderboard()
    {
        YandexGame.NewLeaderboardScores("Passengers", passengersBestScore);
    }

    public void ShowAd()
    {
        YandexGame.FullscreenShow();
    }

    public void LoadData()
    {
        passengersBestScore = YandexGame.savesData.passengersBestScoreDataSave;
        moneyAmount = YandexGame.savesData.moneyDataSave;
        Debug.Log(passengersBestScore);
        Debug.Log("LoadData вызвался, пассажиров: " + passengersBestScore + ", денег: " + moneyAmount);
    }

    public void SaveData()
    {
        passengersBestScore = PlayerPrefs.GetInt("BestScore");
        moneyAmount = PlayerPrefs.GetInt("Money");

        YandexGame.savesData.passengersBestScoreDataSave = passengersBestScore;
        YandexGame.savesData.moneyDataSave = moneyAmount;
        YandexGame.SaveProgress();
        AddNewLiderboard();
    }

    public void JustSaveData()
    {
        YandexGame.SaveProgress();
        AddNewLiderboard();
    }
}
