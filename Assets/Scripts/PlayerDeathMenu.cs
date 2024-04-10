using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using YG;

public class PlayerDeathMenu : MonoBehaviour
{
    public static PlayerDeathMenu instance;


    public int money;

    public string MainMenuSceneName;



    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }


    public void Restart()
    {
        Debug.Log("4. Заново");
        money = YandexGame.savesData.moneyDataSave;
        Debug.Log("5. Кол-во денег после нажатия кнопки Заново = " + money);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        PlayerMove.Instance.Speed = 3f;       
    }

    public void BuyLife()
    {
        money = YandexGame.savesData.moneyDataSave;
        Debug.Log("6. Кол-во денег после нажатия кнопки BuyLife = " + money);
        int requiredMoney = 20000;
        if (money >= requiredMoney)
        {
            money = GameManager.Instance.GetMoney();
            GameManager.Instance.SpendMoney(requiredMoney);
            // Перемещение игрока на 2 метра вперед
            PlayerMove.Instance.MoveForward(4f);
            PlayerMove.Instance.Speed = 3f;
            // Скрытие меню смерти
            gameObject.SetActive(false);
            //PlayerPrefs.SetInt("Money", money);
            YandexGame.savesData.moneyDataSave = money;

            //--------

            //YandexGame.SaveProgress();

            //--------
            Time.timeScale = 1f;
        }
        else
        {
            Debug.Log("Not enough money to buy life!");
        }
    }

    public void LoadMainMenu()
    {
        Debug.Log("7. Кол-во денег после нажатия кнопки LoadMainMenu = " + money);
        money = YandexGame.savesData.moneyDataSave;
        PassengerManager.instance.RecordPassengersScore();
        Debug.Log(MainMenuSceneName);
        SceneManager.LoadScene(MainMenuSceneName);
        Time.timeScale = 1f;
    }
}

