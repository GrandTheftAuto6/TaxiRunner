using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string sceneName; // Имя сцены, которую вы хотите загрузить

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
}
