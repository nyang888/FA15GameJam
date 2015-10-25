using UnityEngine;
using System.Collections;

public class onClickDoStuff : MonoBehaviour
{

    private bool isColliding = false;
    private Collider currentCollider;
    //private GameObject mainCamera;
    private GameObject Cube;
    private Collider objectThatWasPickedUp;
    private bool pickedUp = false;
    private bool NotEnoughquestTime = false;

    // Use this for initialization
    void Start()
    {
        //mainCamera = GameObject.Find("MainCamera");
        Cube = GameObject.Find("Cube");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            Debug.Log("Pressed E");
            dropObject();
            if (isColliding == true)
            {
                Debug.Log("Colliding with some object");
                switch (currentCollider.name)
                {
                    case "OpenBook":
                        Debug.Log("OpenBook");
                        QuestTracker.study = true;
                        break;
                    case "CrumpledPaper":
                        Debug.Log("CrumpledPaper");
                        pickUpObject();
                        break;
                    case "Soda_Can":
                        Debug.Log("Soda Can");
                        pickUpObject();
                        break;
                    case "Stapler":
                    case "Stapler_Bottom":
                    case "Stapler_Metal":
                    case "Stapler_Top":
                        Debug.Log("Stapler");
                        if (Timer.intMinutes >= 1)
                        {
                            QuestTracker.staple = true;
                        }
                        else
                        {
                            NotEnoughquestTime = true;
                        }
                        
                        break;
                    case "Lamp":
                        Debug.Log("Lamp");
                        pickUpObject();
                        break;
                    case "Phone":
                        Debug.Log("Phone");
                        if (Timer.intMinutes >= 1)
                        {
                            QuestTracker.phone = true;
                            pickUpObject();
                        }
                        else
                        {
                            NotEnoughquestTime = true;
                        }
                        break;
                    case "Laptop":
                    case "Laptop_Screen":
                    case "Laptop_Bottom":
                        if (Timer.intMinutes >= 1)
                        {
                            QuestTracker.internet = true;
                        }
                        else
                        {
                            NotEnoughquestTime = true;
                        }
                        Debug.Log("Laptop");
                        break;
                    case "Bed":
                    case "Bed_Base":
                    case "Bed_Pillow":
                    case "Bed_Pillow1":
                    case "Bed_Post1":
                    case "Bed_Post2":
                        if (Timer.intMinutes >= 1)
                        {
                            QuestTracker.sleep = true;
                        }
                        else
                        {
                            NotEnoughquestTime = true;
                        }
                        Debug.Log("Bed");
                        break;
                    case "Chair":
                        Debug.Log("Chair");
                        break;
                    case "TrashCan":
                        Debug.Log("TrashCan");
                        break;
                    case "Toilet2":
                        if (Timer.intMinutes >= 1)
                        {
                            QuestTracker.shit = true;
                        }
                        else
                        {
                            NotEnoughquestTime = true;
                        }
                        Debug.Log("Toilet");
                        break;
                    case "Drawer 1":
                        //currentCollider.GetComponent<Animation>().Play("Open Drawer 1");
                        Debug.Log("DRAWER 1");
                        break;
                    case "Drawer 2":
                        Debug.Log("DRAWER 2");
                        break;
                    case "Drawer 3":
                        Debug.Log("DRAWER 3");
                        break;
                    default:
                        break;
                }

            }
        }

    }

    void OnTriggerEnter(Collider theCollider)
    {

        isColliding = true;
        currentCollider = theCollider;

    }

    void OnTriggerExit(Collider theCollider)
    {
        isColliding = false;
    }

    void OnGUI()
    {
        if (currentCollider != null)
        {
            GUI.Box(new Rect(1200, 40, 100, 30), currentCollider.gameObject.name);
            if (NotEnoughquestTime)
            {
                GUI.Box(new Rect(600, 250, 250, 50), "You don't have enough time \nfor the quest!! You lose!");
            }
        }
    }

    void pickUpObject()
    {
        if (pickedUp == false)
        {
            Debug.Log("Picking up item");

            currentCollider.gameObject.transform.SetParent(Cube.transform);
            currentCollider.attachedRigidbody.useGravity = false;

            currentCollider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            //currentCollider.gameObject.GetComponent<Transform>().position.Set(0, 0, 0);
            //currentCollider.gameObject.GetComponent<Transform>().rotation.Set(80, 180, 0, 1);
            //currentCollider.gameObject.GetComponent<Transform>().Rotate(new Vector3(80, 180, 0));
            //currentCollider.gameObject.transform.position.Set(0, 0, 0);
            //currentCollider.gameObject.transform.rotation.Set(80, 180, 0, 1);
            objectThatWasPickedUp = currentCollider;

            pickedUp = true;
        }
    }

    void dropObject()
    {
        if (pickedUp == true)
        {
            Debug.Log("Droping item");
            objectThatWasPickedUp.gameObject.transform.SetParent(null);
            objectThatWasPickedUp.attachedRigidbody.useGravity = true;
            objectThatWasPickedUp.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            pickedUp = false;
            objectThatWasPickedUp = null;

        }
    }
}
