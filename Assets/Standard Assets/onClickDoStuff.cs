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
        if (isColliding == true)
        {
            if (currentCollider.gameObject.name == "Drawer 1" && Input.GetMouseButtonDown(0))
            {
                //currentCollider.gameObject.PlayAnimation("Open Drawer 1");
                Debug.Log("DRAWER !!!!!!");
                currentCollider = null;
                isColliding = false;
            }
        }
	}

    void OnTriggerEnter(Collider theCollider)
    {
        Debug.Log("OnTriggerEnter");
        isColliding = true;
        currentCollider = theCollider;

    }

    void OnTriggerExit(Collider theCollider)
    {
        Debug.Log("OnTriggerExit");
        isColliding = false;
        currentCollider = null;
    }

}


