using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MainMenu : MonoBehaviour
{
    public string sceneName; // ��� �����, ������� �� ������ ���������

    public int bestMainMenuScore;
    [SerializeField] TextMeshProUGUI _bestScoreText;

    private void Awake()
    {
        bestMainMenuScore = PlayerPrefs.GetInt("BestScore", 0);
        PlayerPrefs.Save();
    }

    private void Start()
    {
        _bestScoreText.text = "������: " + bestMainMenuScore.ToString();
        PlayerPrefs.Save();
    }

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
        Time.timeScale = 1f;
    }
}
