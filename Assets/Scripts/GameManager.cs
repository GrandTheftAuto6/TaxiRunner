using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private int _passengers = 0;
    public int Passengers { get { return _passengers; } }

    public int money;

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

    public void AddMoney(int amount)
    {
        money = PlayerPrefs.GetInt("Money", 0);
        money += amount;
        PlayerPrefs.SetInt("Money", money);
    }

    public void SpendMoney(int amount)
    {
        int money = PlayerPrefs.GetInt("Money", 0);
        money -= amount;
        PlayerPrefs.SetInt("Money", Mathf.Max(0, money)); // ��������, ��� ������ �� ����� ���� � �����
        PassengerManager._moneyCount = money; // ��������� �������� _moneyCount
    }

    public void AddPassenger()
    {
        _passengers++;
    }

    public void ResetPassengersAndSpeed()
    {
        _passengers = 0;
        // �������� ������ ����� ���� �������� �����, ���� ���������
    }

    public int GetMoney()
    {
        return PlayerPrefs.GetInt("Money", money);
    }

    // ������ ������ � �������� �������� ��������� ����� ���� ��������� ����� �� �������������
}