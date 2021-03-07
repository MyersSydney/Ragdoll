using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxMachine : MonoBehaviour
{
    public GameObject box;
    public GameObject spawn;
    public void SpawnBox() {
        Instantiate(box, spawn.transform.position, Quaternion.identity);
    }


}
