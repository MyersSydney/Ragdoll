using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drivethru : MonoBehaviour
{
    public List<Item> newItems = new List<Item>();
    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.gameObject.layer == 12) {
            //if it is a box
            StartList(GameManager.instance.customers.Peek().GetComponent<Customer>().currentRecipe.items);
            CheckBox(collision.collider.gameObject.GetComponent<box>().items);
            Destroy(collision.collider.gameObject);
        }
    }

    void StartList(List<Item> items) {
        for(int i = 0; i < items.Count; i++) {
            newItems.Add(items[i]);
        }
    }

    public bool CheckBox(List<Item> items) {
        for(int i = 0; i < GameManager.instance.customers.Peek().GetComponent<Customer>().currentRecipe.items.Count; i++) {
            
        }
    }
}
