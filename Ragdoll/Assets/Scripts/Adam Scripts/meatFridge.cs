using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class meatFridge : MonoBehaviour
{
    public GameObject foodItem;
    public float price;
    public GameObject player;
    private void Start() {
        player = GameObject.Find("player");
        this.gameObject.GetComponent<Renderer>().material.color = foodItem.GetComponent<cooking>().rawColor;
    }

    private void Update() {
        this.transform.Rotate(0, 20 * Time.deltaTime, 0);
    }
    public void PurchaseItem() {
        if (GameManager.instance.currentMoney >= price) {
            //has enough money to buy
            GameObject obj = Instantiate(foodItem, transform.position, Quaternion.identity);
            player.GetComponent<pickUpObjects>().PickUpFromFridge(obj);
            GameManager.instance.currentMoney -= price;
        }
    }
}
