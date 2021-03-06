using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class objCollision : MonoBehaviour
{
    private void Start() {
        Physics.IgnoreLayerCollision(this.gameObject.layer, 11);
    }
}
