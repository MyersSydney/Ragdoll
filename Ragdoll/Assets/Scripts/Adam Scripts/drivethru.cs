using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class drivethru : MonoBehaviour
{
    public List<Item> newItems = new List<Item>();
    public static drivethru instance;
    private void Awake() {
        if(instance == null) {
            instance = this;
        } else {
            Destroy(this);
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if(collision.collider.gameObject.layer == 12) {
            //if it is a box
            if (CheckBox(collision.collider.gameObject.GetComponent<box>().items)) {
                //good box
                print("This was a good box");
            } else {
                //bad box
                print("This was a bad box");
            }
            Destroy(collision.collider.gameObject);    
        }
    }

    public void StartList(List<Item> items) {
        newItems.Clear();
        for (int i = 0; i < items.Count; i++) {
            newItems.Add(items[i]);
        }
    }
    public bool CheckBox(List<Item> items) {
        for(int i = 0; i < items.Count; i++) {
            for(int j = 0; j < newItems.Count; j++) {
                if(items[i] == newItems[j]) {
                    newItems.RemoveAt(j);
                    break;
                }
            }
        }

        if(newItems.Count == 0) {
            return true;
        } else {
            return false;
        }
    }
}
