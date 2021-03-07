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
    public bool useOnce = false;
    public bool isAngry = false;
    public bool happened = false;
    public float patienceMax;
    public float patienceMin = 100;
    public float patienceTimer;
    float modifier;
    [SerializeField]
    public LayerMask custard;
    AudioSource audio;
    void Start()
    { 
        goPoint = GameObject.FindGameObjectWithTag("GoPoint").transform;
        theGreatBeyond = GameObject.FindGameObjectWithTag("theBeyond").transform;
        /*currentRecipe = GameManager.instance.GetRecipe();*/
        currentRecipe = GameManager.instance.CreateOrder();
        
        audio = GetComponent<AudioSource>();
        if (GameManager.instance.kelpRating > 0.6)
            modifier = .4f;
        if (GameManager.instance.kelpRating <= 0.6 && GameManager.instance.kelpRating > 0.5)
            modifier = .2f;
        if ( GameManager.instance.kelpRating <= 0.5 && GameManager.instance.kelpRating > 0.4)
            modifier = 0;
        if (GameManager.instance.kelpRating <= 0.4 && GameManager.instance.kelpRating > 0.3)
            modifier = -.2f;
        if (GameManager.instance.kelpRating <= 0.3 && GameManager.instance.kelpRating > 0.2)
            modifier = -.4f;

        patienceMax = patienceMin + patienceMin * modifier;
        if(patienceMax > patienceMin)
            patienceTimer = Random.Range(patienceMin, patienceMax);
        else
            patienceTimer = Random.Range(patienceMax, patienceMin);

        audio.clip = GameManager.instance.custArrive;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit,30, custard))
        {
            print(hit);
/*            if(hit.collider.CompareTag("customer"))
            {*/
                moving = false;
           /* }*/
        }
        if ((patienceTimer <= 0 && !isSated) || isAngry)
        {
            isAngry = true;
            PlaySound(GameManager.instance.bad,false);
            print("I'm out of patience");
            transform.Translate(Vector3.forward);//Vector3.MoveTowards(this.gameObject.transform.position, theGreatBeyond.position, speed * Time.deltaTime);
        }
        if(patienceTimer > 0 && !isSated)
        {
            patienceTimer -= Time.deltaTime;
        }
        if (moving && !isSated)
        {
            transform.position = Vector3.MoveTowards(this.gameObject.transform.position, goPoint.position, speed * Time.deltaTime);
        }
        if(isSated && !isAngry)
        {
            PlaySound(GameManager.instance.good, true);
            transform.position = Vector3.MoveTowards(this.gameObject.transform.position, theGreatBeyond.position, speed * Time.deltaTime);   
        }
        if(!useOnce && (isSated || isAngry)) {
            GameManager.customers.Dequeue();
            Invoke("letsEndThis", 30f);
            useOnce = true;
        }
    }
    void PlaySound(AudioClip a, bool howHappened)
    {
        if (!happened)
        {
            if (howHappened)
            {
                GameManager.instance.kelpRating += 0.005f;
            }
            else
            {
                GameManager.instance.kelpRating -= 0.005f;
            }
            audio.clip = a;
            audio.Play();
            happened = true;
        }
    }
    private void letsEndThis()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter(Collider other)
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
