using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cooking : MonoBehaviour
{

    //goes on the items that need to be cooked
    public float cookTimer;
    public Color cookedColor;
    public Color rawColor;
    public float timeHasCooked;

    public bool cookingFood;
    private void Start() {
        this.gameObject.GetComponent<Renderer>().material.color = rawColor;
    }

    private void Update() {
        if (cookingFood) {
            
            
        }
    }
    private void OnCollisionEnter(Collision collision) {
        if (collision.collider.gameObject.CompareTag("Stove")) {

            //if it is on the stove
            StartCoroutine(CookTheFood());
        }
    }
    private void OnCollisionExit(Collision collision) {
        if (collision.collider.gameObject.CompareTag("Stove")) {

            //if it is on the stove
            StopAllCoroutines();
        }
    }

    IEnumerator CookTheFood() {
        while(this.gameObject.GetComponent<Renderer>().material.color != cookedColor) {
            float percent = timeHasCooked / cookTimer;
            this.gameObject.GetComponent<Renderer>().material.color = Color.Lerp(rawColor, cookedColor, percent);
            timeHasCooked += Time.deltaTime;
            yield return new WaitForSeconds(0.01f);
        }
    }
}
