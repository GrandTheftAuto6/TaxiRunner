using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System;

public class PassengerManager : MonoBehaviour
{
    [SerializeField] int _numberOfPassengersInLevel;
    [SerializeField] int _moneyCount = 0;
    [SerializeField] int _moneyPerPassenger;
    [SerializeField] float _speedCount;
    [SerializeField] float _roundedSpeedCount;
    [SerializeField] TextMeshProUGUI _passengersText;
    [SerializeField] TextMeshProUGUI _moneyText;
    [SerializeField] TextMeshProUGUI _speedText;

    public void AddOne()
    {
        _speedCount = PlayerMove._speed += 0.05f;
        _roundedSpeedCount = (float)Math.Round(_speedCount, 2);

        _numberOfPassengersInLevel++;
        _moneyCount += _moneyPerPassenger;
        _passengersText.text = _numberOfPassengersInLevel.ToString();
        _moneyText.text = "$" + _moneyCount.ToString();
        _speedText.text = Mathf.RoundToInt(_roundedSpeedCount * 10).ToString() + " κμ/χ";
    }
}
