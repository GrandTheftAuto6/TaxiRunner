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
        Debug.Log(passengersBestScore);
    }

    public void SaveData()
    {
        passengersBestScore = PlayerPrefs.GetInt("BestScore");
        YandexGame.savesData.passengersBestScoreDataSave = passengersBestScore;
        YandexGame.SaveProgress();
        AddNewLiderboard();
    }
}
