using UnityEngine;
using System.Collections;

public class onClickDoStuff : MonoBehaviour {

    private bool isColliding;
    private Collider currentCollider;
	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (isColliding == true && Input.GetMouseButtonDown(0))
        {
            switch (currentCollider.gameObject.name)
            {
                case "Drawer 1": 
                    //currentCollider.gameObject.PlayAnimation("Open Drawer 1");
                    //currentCollider.gameObject.GetComponent<Animation>().Play();
                    Debug.Log("DRAWER !!!!!!");
                    currentCollider = null;
                    isColliding = false;
                    break;
                case "Phone":
                    Debug.Log("PHONE!!!!");
                    currentCollider = null;
                    isColliding = false;
                    break;
                case "Laptop":
                    Debug.Log("LAPTOP!!!!");
                    currentCollider = null;
                    isColliding = false;
                    QuestTracker.internet = true;
                    break;
                case "Bed":
                    Debug.Log("BED!!!!");
                    currentCollider = null;
                    isColliding = false;
                    QuestTracker.sleep = true;
                    break;
                default:
                    break;
            }

        }
	}

    void OnTriggerEnter(Collider theCollider)
    {
        //Debug.Log("OnTriggerEnter");
        isColliding = true;
        currentCollider = theCollider;

    }

    void OnTriggerExit(Collider theCollider)
    {
        //Debug.Log("OnTriggerExit");
        isColliding = false;
        if (currentCollider != null)
        {
            currentCollider = null;
        }
    }

}


