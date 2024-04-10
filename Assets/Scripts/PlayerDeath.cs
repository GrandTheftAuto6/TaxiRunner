using UnityEngine;
using YG;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject _deathMenu;
    public int moneyAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            Debug.Log("1. Игрок умер");
            moneyAmount = YandexGame.savesData.moneyDataSave;
            Debug.Log("2. Оно же 12. PlayerDeath: кол-во денег полученое из Gamemanager.GetMoney " + moneyAmount);
            PassengerManager.instance.RecordPassengersScore();
            Debug.Log("moneyAmount = " + moneyAmount);           
            YandexGame.savesData.moneyDataSave = moneyAmount;
            Debug.Log("3. Деньги сохранены в облако в PlayerDeath скрипте. Их - " + moneyAmount);
            YandexPlugin._instance.JustSaveData();
            Debug.Log("3. Деньги сохранены в облако в PlayerDeath скрипте. Их - " + moneyAmount);


            Time.timeScale = 0f;
            _deathMenu.SetActive(true);
            PlayerMove.Instance.Speed = 0f;
            GameManager.Instance.ResetPassengersAndSpeed();
        }
    }
}