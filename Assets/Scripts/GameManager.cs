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
    public int moneyFinal;


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

        money = YandexGame.savesData.moneyDataSave;
        Debug.Log("8. GameManager. Awake Кол-во денег после попадания в Level01 = " + money);

    }

    public void AddMoney(int amount)
    {
        //money = PlayerPrefs.GetInt("Money", 0);
        money = YandexGame.savesData.moneyDataSave;
        Debug.Log("9. Подбираю пассажира (GameManager, AddMoney) Кол-во денег после попадания в Level01 = " + money);
        money += amount;
        Debug.Log("10. Подобрал пассажира (GameManager, AddMoney) Кол-во денег после попадания в Level01 = " + money);
        //PlayerPrefs.SetInt("Money", money);
        YandexGame.savesData.moneyDataSave = money;
        moneyFinal = money;
        Debug.Log("11. Денег в moneyFinal = " + moneyFinal);
        YandexPlugin._instance.JustSaveData();
    }

    public void SpendMoney(int amount)
    {
        //int money = PlayerPrefs.GetInt("Money");
        money = YandexGame.savesData.moneyDataSave;
        money -= amount;
        //PlayerPrefs.SetInt("Money", Mathf.Max(0, money)); // Убедимся, что деньги не могут уйти в минус
        YandexGame.savesData.moneyDataSave = money;
        moneyFinal = money;
        YandexGame.SaveProgress();
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
        //return PlayerPrefs.GetInt("Money", money);
        return moneyFinal;
        Debug.Log("12. GameManager, GetMoney. Кол-во денег в переменной moneyFinal " + moneyFinal);
    }

    // Другие методы и свойства игрового менеджера могут быть добавлены здесь по необходимости
}