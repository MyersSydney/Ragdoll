using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objCollision : MonoBehaviour
{
    public Item item;
    private void Start() {
        Physics.IgnoreLayerCollision(this.gameObject.layer, 11);
        Physics.IgnoreLayerCollision(this.gameObject.layer, 13);
    }
}
