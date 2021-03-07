using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class timer : MonoBehaviour
{

    public TextMeshPro clock;

    private void Update() {
        clock.text = GameManager.customers.Peek().gameObject.GetComponent<Customer>().patienceTimer.ToString("0");
    }

}
