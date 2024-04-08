using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject _deathMenu;
    public int moneyAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            PassengerManager.instance.RecordPassengersScore();
            moneyAmount = PassengerManager._moneyCount;
            Debug.Log("moneyCount = " + moneyAmount);
            PlayerPrefs.SetInt("Money", moneyAmount);
            Progress.Instance.PlayerInfo.Money = moneyAmount;

            Progress.Instance.Save();

            Time.timeScale = 0f;
            _deathMenu.SetActive(true);
            PlayerMove.Instance.Speed = 0f;
            GameManager.Instance.ResetPassengersAndSpeed();
        }
    }
}