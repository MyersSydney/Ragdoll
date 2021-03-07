
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
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
    GameObject[] myCustomers;
    public static GameManager instance;
    public bool isPlaying = true;
    public bool waiting = true;
    float waitTimer = 30;
    public bool isSpawning = true;
    public float chanceSpawnMin = 1;
    public float chanceSpawnMax = 100;
    public float downTime = 30;
    public int maxCustomers = 5;
    [SerializeField]
    public static Queue<GameObject> customers = new Queue<GameObject>();
    [SerializeField]
    Recipe[] recipes;
    [SerializeField]
    Item[] ingredients;
    [SerializeField]
    Item[] bun;
    [SerializeField]
    Item[] meats;
    [SerializeField]
    public AudioClip bad;
    [SerializeField]
    public AudioClip good;
    [SerializeField]
    public AudioClip custArrive;
    
    [Header("Whiteboard")]
    public TextMeshPro whiteBoardText;

    // Start is called before the first frame update
    void Awake()
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
           /* if(Random.Range(chanceSpawnMin, chanceSpawnMax) < 2 && isSpawning)
            {
                isSpawning = !isSpawning;
                print(isSpawning);
            }*/
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
    public Recipe GetRecipe()
    {
        return recipes[Random.Range(0, recipes.Length)];
    }
    public Recipe CreateOrder()
    {
        Recipe r = (Recipe)ScriptableObject.CreateInstance("Recipe");
        int max = Random.Range(5, 10);
        r.items.Add(bun[Random.Range(0, bun.Length- 1)]);
        r.items.Add(meats[Random.Range(0, meats.Length -1)]);
        for (int i = 0; i < max; i++)
        {
            r.items.Add(ingredients[Random.Range(0, ingredients.Length)]);
        }
        return r;
    }
    void spawnCustomer()
    {
        int i = Random.Range(0, myCustomers.Length - 1);
        GameObject obj = Instantiate(myCustomers[i], spawnPoint.position, this.transform.localRotation);
        customers.Enqueue(obj);
        waiting = true;
    }
    public void ModifyRating(Item i, float time, bool isMeat)
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

                break;
            case Item.Quality.poor:

                break;
        }
        if (i.quality == Item.Quality.amazing)
        {

        }
    }
}
