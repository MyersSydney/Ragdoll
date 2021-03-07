using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    // Start is called before the first frame update
    public Recipe currentRecipe;
    public Transform goPoint;
    public Transform theGreatBeyond;
    public bool moving = true;
    public float speed = 10;
    public bool isSated = false;
    void Start()
    {
        goPoint = GameObject.FindGameObjectWithTag("GoPoint").transform;
        theGreatBeyond = GameObject.FindGameObjectWithTag("theBeyond").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (moving && !isSated)
        {
            transform.position = Vector3.MoveTowards(this.gameObject.transform.position, goPoint.position, speed * Time.deltaTime);
        }
        if(isSated)
        {
            transform.position = Vector3.MoveTowards(this.gameObject.transform.position, theGreatBeyond.position, speed * Time.deltaTime);
            GameManager.customers.Dequeue();
            Invoke("letsEndThis", 30f);
        }
    }
    private void letsEndThis()
    {
        Destroy(gameObject);
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("customer"))
        {
            moving = false;
        }
       

    }

    private void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("customer"))
        {
            moving = true;
        }
    }
}
