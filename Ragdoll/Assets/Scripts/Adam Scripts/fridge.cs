using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fridge : MonoBehaviour
{
    public float speed;
    public GameObject placeholder;
    public GameObject otherPlaceHolder;
    Quaternion origin;
    Quaternion opened;
    public float timer;

    public bool eventBool;
    private void Start() {
        origin = otherPlaceHolder.transform.rotation;
        opened = placeholder.transform.rotation;
    }
    private void Update() {
        if (eventBool) {
            timer -= Time.deltaTime;
            if (timer <= 0) {
                timer = 0;
                StopAllCoroutines();
                eventBool = false;
            }
        }
        if (Input.GetKeyDown(KeyCode.E)) {
            StartCoroutine(OpenFridge());
        } else if (Input.GetKeyDown(KeyCode.F)) {
            StartCoroutine(CloseFridge());
        }


    }
    IEnumerator OpenFridge() {
        timer = 6;
        eventBool = true;
        while(this.transform.rotation != opened) {
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, opened, -1 * speed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
        this.transform.rotation = opened;
    }

    IEnumerator CloseFridge() {
        timer = 6f;
        eventBool = true;
        while (this.transform.rotation != origin) {
            this.transform.rotation = Quaternion.RotateTowards(this.transform.rotation, origin, -1 * speed * Time.deltaTime);
            yield return new WaitForSeconds(0.01f);
        }
        this.transform.rotation = origin;
    }

}
