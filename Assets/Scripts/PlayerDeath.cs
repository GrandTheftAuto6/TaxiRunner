using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    [SerializeField] private GameObject _deathMenu;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Barrier"))
        {
            Time.timeScale = 0f;
            _deathMenu.SetActive(true);
            PlayerMove.Instance.Speed = 0f;
            GameManager.Instance.SaveGameData(); // —охран€ем данные при столкновении с барьером
            GameManager.Instance.ResetPassengersAndSpeed();
        }
    }
}