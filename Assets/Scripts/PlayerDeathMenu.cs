using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class PlayerDeathMenu : MonoBehaviour
{
    public int money;

    public string MainMenuSceneName;

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        PlayerMove.Instance.Speed = 3f;
        PlayerPrefs.GetInt("Money", money);
    }

    public void BuyLife()
    {
        int money = GameManager.Instance.GetMoney();
        int requiredMoney = 20000;
        if (money >= requiredMoney)
        {
            GameManager.Instance.SpendMoney(requiredMoney);
            money = GameManager.Instance.GetMoney();
            // ����������� ������ �� 2 ����� ������
            PlayerMove.Instance.MoveForward(4f);
            PlayerMove.Instance.Speed = 3f;
            // ������� ���� ������
            gameObject.SetActive(false);
            PlayerPrefs.SetInt("Money", money);
            Time.timeScale = 1f;
        }
        else
        {
            Debug.Log("Not enough money to buy life!");
        }
    }

    public void LoadMainMenu()
    {
        PassengerManager.instance.RecordPassengersScore();
        Debug.Log(MainMenuSceneName);
        SceneManager.LoadScene(MainMenuSceneName);
        Time.timeScale = 1f;
    }
}

