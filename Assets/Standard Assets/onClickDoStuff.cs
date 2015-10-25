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
            if (pickedUp == true)
            {
                Debug.Log("Droping item");
                objectThatWasPickedUp.gameObject.transform.SetParent(null);
                objectThatWasPickedUp.attachedRigidbody.useGravity = true;
                objectThatWasPickedUp = currentCollider;
                currentCollider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                //RigidbodyConstraints.None;
                pickedUp = false;
                objectThatWasPickedUp = null;

            }
            else if (isColliding == true)
            {
                Debug.Log("Colliding with some object");
                switch (currentCollider.name)
                {
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
                    case "Phone":
                        Debug.Log("Phone");
                        QuestTracker.phone = true;
                        if (pickedUp == false)
                        {
                            Debug.Log("Picking up item");

                            currentCollider.gameObject.transform.SetParent(Cube.transform);
                            currentCollider.attachedRigidbody.useGravity = false;

                            currentCollider.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;



                            currentCollider.gameObject.GetComponent<Transform>().position.Set(0, 0, 0);
                            currentCollider.gameObject.GetComponent<Transform>().rotation.Set(80, 180, 0, 1);
                            //currentCollider.gameObject.transform.position.Set(0, 0, 0);
                            //currentCollider.gameObject.transform.rotation.Set(80, 180, 0, 1);
                            objectThatWasPickedUp = currentCollider;

                            pickedUp = true;
                        }
                        break;
                    case "Laptop":
                    case "Laptop_Screen":
                    case "Laptop_Bottom":
                        QuestTracker.internet = true;
                        Debug.Log("Laptop");
                        break;
                    case "Bed":
                        QuestTracker.sleep = true;
                        Debug.Log("Bed");
                        break;
                    case "Chair":
                        Debug.Log("Chair");
                        break;
                    case "TrashCan":
                        Debug.Log("TrashCan");
                        break;
                    case "Toilet2":
                        QuestTracker.shit = true;
                        Debug.Log("Toilet");
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
        }
    }

}
