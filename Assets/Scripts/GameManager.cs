using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using YG;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private int _passengers = 0;
    public int Passengers { get { return _passengers; } }

    public int money, moneyAmount;


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

        YandexPlugin._instance.LoadData();

        money = moneyAmount;
    }

    public void AddMoney(int amount)
    {
        money = PlayerPrefs.GetInt("Money", 0);
        money += amount;
        PlayerPrefs.SetInt("Money", money);
        YandexPlugin._instance.SaveData();
    }

    public void SpendMoney(int amount)
    {
        int money = PlayerPrefs.GetInt("Money");
        money -= amount;
        PlayerPrefs.SetInt("Money", Mathf.Max(0, money)); // Убедимся, что деньги не могут уйти в минус
        PassengerManager._moneyCount = money; // Обновляем значение _moneyCount
    }

    public void AddPassenger()
    {
        _passengers++;
    }

    public void ResetPassengersAndSpeed()
    {
        _passengers = 0;
        // Скорость игрока может быть сброшена здесь, если требуется
    }

    public int GetMoney()
    {
        return PlayerPrefs.GetInt("Money", money);
    }

    // Другие методы и свойства игрового менеджера могут быть добавлены здесь по необходимости
}