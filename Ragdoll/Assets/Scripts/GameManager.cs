
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public float money;
    public float currentMoney;
    public float kelpRating = 0.5f;
    public float personTimer;
    public float initialKelp = 0.5f;
    public float initialMoney = 500f;
    [SerializeField]
    Transform spawnPoint;
    [SerializeField]
    GameObject customer;
    public static GameManager instance;
    public bool isPlaying = true;
    public bool waiting = true;
    float waitTimer = 30;
    public bool isSpawning = true;
    public float chanceSpawnMin = 1;
    public float chanceSpawnMax = 100;
    public float downTime = 30;
    public int maxCustomers = 5;
    public Queue<GameObject> customers = new Queue<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        if (instance == null)
            instance = this;
        else Destroy(gameObject);
        NormalizeValues();
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if(spawnPoint == null && isPlaying)
        {
            spawnPoint = GameObject.FindGameObjectWithTag("customerSpawn").transform;
        } 
        if(isPlaying)
        {
            if(Random.Range(chanceSpawnMin, chanceSpawnMax) < 2 && isSpawning)
            {
                isSpawning = !isSpawning;
                print(isSpawning);
            }
            //if the customers are spawning and are less than the max number of spawned customers
            //Have yet to implement the limiting of customers
            //will store alive customers in a Queue and then release them as the orders are processed
            if (isSpawning)
            {
                //happens when 
                if (!waiting && customers.Count <= maxCustomers)
                    spawnCustomer();
                else //if waiting minus timer
                {
                    waitTimer -= Time.deltaTime;
                }
                //if we are waiting and the timer has reached 0
                if(waiting && waitTimer <= 0)
                {
                    waitTimer = 30;
                    waiting = !waiting;
                }
            }
            //is not spawning and down time is still not zero
            if (!isSpawning)
                downTime -= Time.deltaTime;
            //Resets to spawning customers
            if(!isSpawning && downTime <= 0)
            {
                downTime = 30;
                isSpawning = !isSpawning;
                print(isSpawning);
            }
        }
    } 
    void NormalizeValues()
    {
        kelpRating = initialKelp;
        money = initialMoney;
        currentMoney = money;

    }
    void spawnCustomer()
    {
        GameObject obj = Instantiate(customer, spawnPoint.position, Quaternion.identity);
        customers.Enqueue(obj);
        waiting = true;
    }
    public void ModifyRating(Item i, float time)
    {
        switch (i.quality)
        {
            case Item.Quality.theBomb:

                break;
            case Item.Quality.amazing:

                break;

            case Item.Quality.awesome:

                break;
            case Item.Quality.good:
                if (i.GetType() == typeof(Meat))
                {

                }
                break;
            case Item.Quality.poor:

                break;
        }
        if (i.quality == Item.Quality.amazing)
        {

        }
    }
}
