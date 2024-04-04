using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0f; // Останавливаем время
        pauseMenuUI.SetActive(true); // Показываем меню паузы
        isPaused = true;
    }

    public void Resume()
    {
        Time.timeScale = 1f; // Возобновляем время
        pauseMenuUI.SetActive(false); // Скрываем меню паузы
        isPaused = false;
    }
}
