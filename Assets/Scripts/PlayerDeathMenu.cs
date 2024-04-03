using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathMenu : MonoBehaviour
{
    public int money;

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
        int requiredMoney = 500;
        if (money >= requiredMoney)
        {
            GameManager.Instance.SpendMoney(requiredMoney);
            money = GameManager.Instance.GetMoney();
            // Перемещение игрока на 2 метра вперед
            PlayerMove.Instance.MoveForward(4f);
            // Скрытие меню смерти
            gameObject.SetActive(false);
            PlayerPrefs.SetInt("Money", money);
            Time.timeScale = 1f;
        }
        else
        {
            Debug.Log("Not enough money to buy life!");
        }
    }
}
