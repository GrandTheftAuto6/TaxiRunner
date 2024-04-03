using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeathMenu : MonoBehaviour
{
    public void Restart()
    {
        GameManager.Instance.SaveGameData(); // ���������� ������ ����� �������������
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
        PlayerMove.Instance.Speed = 3f;
    }

    public void BuyLife()
    {
        // �������� ������� ������������ ���������� �����
        if (GameManager.Instance.Money >= 20000)
        {
            GameManager.Instance.SpendMoney(20000); // ��������� ������
            // ����������� ������ �� 2 ����� ������
            PlayerMove.Instance.MoveForward(2f);
            // ������� ���� ������
            gameObject.SetActive(false);
        }
    }
}
