using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathMenu : MonoBehaviour
{
    public void Restart()
    {
        GameManager.Instance.SaveGameData(); // Сохранение данных перед перезагрузкой
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        PlayerMove.Instance.Speed = 3f;
    }

    public void BuyLife()
    {
        // Проверка наличия достаточного количества денег
        if (GameManager.Instance.Money >= 20000)
        {
            GameManager.Instance.SpendMoney(20000); // Списываем деньги
            // Перемещение игрока на 2 метра вперед
            PlayerMove.Instance.MoveForward(2f);
            // Скрытие меню смерти
            gameObject.SetActive(false);
        }
    }
}
