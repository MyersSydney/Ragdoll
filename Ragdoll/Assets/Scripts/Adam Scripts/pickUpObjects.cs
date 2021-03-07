using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class pickUpObjects : MonoBehaviour
{

    [SerializeField] private float maxDistance;
    [SerializeField] Transform handLocation;
    [SerializeField] LayerMask pickupMask;

    public bool isHolding;

    [SerializeField] private float force;
    [SerializeField] private float forceOrigin;

    public List<GameObject> objects = new List<GameObject>();

    public TextMeshProUGUI boxText;

    private void Start() {
        forceOrigin = force;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)) {
            if (!isHolding) {
                force = forceOrigin;
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if(Physics.Raycast(ray, out hit, maxDistance)) {
                    if (hit.collider.gameObject.CompareTag("Pickup")) {
                        GameObject obj = hit.collider.gameObject;
                        objects.Add(obj);
                        obj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
                        obj.GetComponent<Rigidbody>().useGravity = false;
                        obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
                        obj.transform.parent = handLocation.transform;

                        obj.GetComponent<Rigidbody>().drag = 100;
                        obj.transform.localPosition = Vector3.zero;
                        isHolding = true;
                    } else if (hit.collider.gameObject.CompareTag("FridgeItem")) {
                        //you are picking something from the fridge
                        GameObject obj = hit.collider.gameObject;
                        obj.GetComponent<fridgeItem>().PurchaseItem();
                    } else if (hit.collider.gameObject.CompareTag("FryButton")) {
                        GameObject obj = hit.collider.gameObject;
                        obj.GetComponent<fryMachine>().FryShoot();
                    } else if (hit.collider.gameObject.CompareTag("meatFridge")) {
                        GameObject obj = hit.collider.gameObject;
                        obj.GetComponent<meatFridge>().PurchaseItem();
                    }
                } 
            } else { //Drop item
                GameObject obj = objects[0].gameObject;
                obj.GetComponent<Rigidbody>().useGravity = true;
                obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                obj.GetComponent<Rigidbody>().drag = 0;
                obj.transform.parent = null;
                objects.Clear();
                isHolding = false;


            }
        } else if (Input.GetMouseButtonDown(1)) { //chuck item at shark
            GameObject obj = objects[0].gameObject;
            obj.GetComponent<Rigidbody>().useGravity = true;
            obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            obj.GetComponent<Rigidbody>().drag = 0;
            if (transform.GetComponent<PlayerController>().velocity.z < 0) {
                force = force / 2 * -1;
                obj.GetComponent<Rigidbody>().AddForce(handLocation.transform.forward * force, ForceMode.Impulse);
            } else if (transform.GetComponent<PlayerController>().velocity.z >= 0) {
                force = force * 2;
                obj.GetComponent<Rigidbody>().AddForce(handLocation.transform.forward * force, ForceMode.Impulse);
            }

            obj.transform.parent = null;
            objects.Clear();
            isHolding = false;
        }
    }


    public void TurnOn(GameObject obj) {

    }

    public void PickUpFromFridge(GameObject obj) {
        obj.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0);
        obj.GetComponent<Rigidbody>().useGravity = false;
        obj.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
        obj.transform.parent = handLocation.transform;

        obj.GetComponent<Rigidbody>().drag = 100;
        obj.transform.localPosition = Vector3.zero;
        isHolding = true;
        objects.Add(obj);
    }
}



