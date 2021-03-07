using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box : MonoBehaviour
{

    public List<Item> items = new List<Item>();

    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.CompareTag("Pickup")) {
            GameObject obj = collision.collider.gameObject;
            if(GameObject.Find("player").GetComponent<pickUpObjects>().objects.Count == 0) {
                //checks to see if the player is holding this object
                items.Add(obj.GetComponent<objCollision>().item);
                Destroy(obj);
            }       
        }
    }
}
