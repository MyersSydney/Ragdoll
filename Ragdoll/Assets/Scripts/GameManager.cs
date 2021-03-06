using System;
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
            spawnCustomer();
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
        Instantiate(customer, spawnPoint.position, Quaternion.identity);
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
                if(i.GetType() == typeof(Meat))
                {

                }
                break;
            case Item.Quality.poor:

                break;
        }
        if(i.quality == Item.Quality.amazing)
        {

        }
    }
}
