using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish : MonoBehaviour
{
    public float speed;
    private void Start() {
        Invoke("EnditAll", 30);
    }
    private void Update() {
        this.gameObject.GetComponent<Rigidbody>().velocity = Vector3.right * speed *-1;
    }

    void EnditAll() {
        Destroy(this.gameObject);
    }
}
