using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Playables;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance { get { return _instance; } }

    private int _money = 0;
    public int Money { get { return _money; } }

    private int _passengers = 0;
    public int Passengers { get { return _passengers; } }

    private float _speed = 3f;
    public float Speed { get { return _speed; } }


    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
            LoadGameData(); // Загрузка данных при запуске игры
        }
    }


    public void AddMoney(int amount)
    {
        _money += amount;
    }


    public void SpendMoney(int amount)
    {
        _money -= amount;
    }


    public void AddPassenger()
    {
        _passengers++;
    }


    public void ResetPassengersAndSpeed()
    {
        _passengers = 0;
        _speed = 3f;
    }


    public void SaveGameData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/gameData.dat";
        FileStream stream = new FileStream(path, FileMode.Create);

        GameData data = new GameData(_money);

        formatter.Serialize(stream, data);
        stream.Close();
    }


    public void LoadGameData()
    {
        string path = Application.persistentDataPath + "/gameData.dat";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            GameData data = formatter.Deserialize(stream) as GameData;
            stream.Close();

            // Проверяем, если данные о деньгах равны нулю, используем другое значение
            _money = data.money == 0 ? 1000 : data.money; // Например, значение по умолчанию 1000
        }
        else
        {
            Debug.LogWarning("Save file not found");
        }
    }
}
