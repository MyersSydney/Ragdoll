using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fryMachine : MonoBehaviour
{

    public GameObject fry;
    public float price;
    public GameObject spawn;
    public void FryShoot() {
        if(GameManager.instance.currentMoney >= price) {
            GameObject obj = Instantiate(fry, spawn.transform.position, Quaternion.identity);
            GameManager.instance.currentMoney -= price;
        }
    }

}
