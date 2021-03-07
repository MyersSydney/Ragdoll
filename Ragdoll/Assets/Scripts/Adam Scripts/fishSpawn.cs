using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishSpawn : MonoBehaviour
{

    public GameObject fish;
    public float timer;
    private void Update() {
        timer -= Time.deltaTime;
        if(timer <= 0) {
            SpawnFish();
            timer = 3;
        }
    }
    void SpawnFish() {
        int rand1 = Random.Range(1, 30); //z
        int rand2 = Random.Range(3, 30); //y
        //x = 80
        GameObject obj = Instantiate(fish, new Vector3(80, rand2, rand1), Quaternion.identity);
        obj.GetComponent<Renderer>().material.color = new Color32((byte)Random.Range(0, 255), (byte)Random.Range(0, 255), (byte)Random.Range(0, 255), 255);
        obj.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}
