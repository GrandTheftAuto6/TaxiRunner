using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Passenger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<PassengerManager>().AddOne();
        Destroy(gameObject);
    }
}
