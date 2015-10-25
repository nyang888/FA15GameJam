using UnityEngine;
using System.Collections;

public class onClickDoStuff : MonoBehaviour
{

    private bool isColliding;
    private Collider currentCollider;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) == true)
        {
            Debug.Log("Message 1");
            if (isColliding == true)
            {
                Debug.Log("Message 2");
                switch (currentCollider.name)
                {
                    case "Drawer 1":
                        //currentCollider.gameObject.GetComponent<Animation>().Play();
                        Debug.Log("DRAWER 1");
                        break;
                    case "Drawer 2":
                        Debug.Log("DRAWER 2");
                        break;
                    case "Drawer 3":
                        Debug.Log("DRAWER 3");
                        break;
                    case "Desk":
                        Debug.Log("Desk");
                        break;
                    case "Phone":
                        Debug.Log("Phone");
                        break;
                    case "Laptop_Screen":
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
                    case "Toilet":
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

}
