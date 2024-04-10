using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System;
using YG;

public class PassengerManager : MonoBehaviour
{
    public static PassengerManager instance;

    public int moneyAmount;

    [SerializeField] int _numberOfPassengersInLevel;
    public static int _moneyCount = 0;
    [SerializeField] int _moneyPerPassenger;
    [SerializeField] float _speedCount;
    [SerializeField] float _roundedSpeedCount;
    [SerializeField] TextMeshProUGUI _passengersText;
    [SerializeField] TextMeshProUGUI _moneyText;
    [SerializeField] TextMeshProUGUI _speedText;


    public static int moneyInPassengerManager;


    private void Awake()
    {
        moneyInPassengerManager = PlayerDeathMenu.instance.money;
        instance = this;
        _moneyCount = moneyInPassengerManager;
        Debug.Log("PASSANGERMANAGER AWAKE: ÊÎË-ÂÎ ÌÎÍÅÒ = " + _moneyCount);
    }




    public void AddOne()
    {
        _speedCount = PlayerMove._speed += 0.05f;
        _roundedSpeedCount = (float)Math.Round(_speedCount, 2);

        _numberOfPassengersInLevel++;
        _moneyCount += _moneyPerPassenger;
        Debug.Log("âàæíî PASSANGERMANAGER ADDONE: ïîñëå äîáàâëåíèÿ ïàññàæèðà ÊÎË-ÂÎ ÌÎÍÅÒ = " + _moneyCount);
        _passengersText.text = _numberOfPassengersInLevel.ToString();
        YandexGame.savesData.moneyDataSave = _moneyCount;
        YandexGame.SaveProgress();
        _moneyText.text = "$" + _moneyCount.ToString();
        _speedText.text = Mathf.RoundToInt(_roundedSpeedCount * 10).ToString() + " êì/÷";
    }

    public void RecordPassengersScore()
    {
        int score = _numberOfPassengersInLevel;
        int bestScore = PlayerPrefs.GetInt("BestScore", 0);

        if (score > bestScore)
        {
            PlayerPrefs.SetInt("BestScore", score);
            PlayerPrefs.Save();
        }
    }
}
