using UnityEngine;
using System.Collections;

public class onClickDoStuff : MonoBehaviour
{

    private bool isColliding = false;
    private Collider currentCollider;

    public AudioSource audio;
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
            if (pickedUp == true)
            {
                //dropObject();
                Debug.Log("Droping item");
                objectThatWasPickedUp.gameObject.transform.SetParent(null);
                objectThatWasPickedUp.attachedRigidbody.useGravity = true;
                objectThatWasPickedUp.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
                pickedUp = false;
                objectThatWasPickedUp = null;
            }
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
                    case "Pencil":
                        Debug.Log("Pencil");
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
                        if (!audio.isPlaying)
                        {
                            audio.Play();
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
			if (currentCollider != null)
			{
				if(currentCollider.gameObject.name == "OpenBook"){
					GUI.Box(new Rect(1200, 40, 200, 30), "Study For Your Test");
				}
				else if(currentCollider.gameObject.name == "CrumpledPaper")
				{
					GUI.Box(new Rect(1200, 40, 200, 30), "Pick Up Paper");
				}
				else if(currentCollider.gameObject.name == "Soda_Can")
				{
					GUI.Box(new Rect(1200, 40, 200, 30), "Pick Up Soda Can");
				}
				else if(currentCollider.gameObject.name == "Phone")
				{
					GUI.Box(new Rect(1200, 40, 200, 30), "Call Mom");
				}
				else if(currentCollider.gameObject.name == "Lamp")
				{
					GUI.Box(new Rect(1200, 40, 200, 30), "Pick Up Lamp");
				}
				else if(currentCollider.gameObject.name == "Toilet2")
				{
					GUI.Box(new Rect(1200, 40, 200, 30), "Use the Toilet");
				}
				else if(currentCollider.gameObject.name == "Pencil")
				{
					GUI.Box(new Rect(1200, 40, 200, 30), "Pick up Pencil");
				}
				else if(currentCollider.gameObject.name == "Bed" || currentCollider.gameObject.name == "Bed_Base" || currentCollider.gameObject.name == "Bed_Pillow" || currentCollider.gameObject.name == "Bed_Pillow1" || currentCollider.gameObject.name == "Bed_Post1" || currentCollider.gameObject.name == "Bed_Post2")
				{
					GUI.Box(new Rect(1200, 40, 200, 30), "Take a Nap");
				}
				else if(currentCollider.gameObject.name == "Stapler" || currentCollider.gameObject.name == "Stapler_Bottom" || currentCollider.gameObject.name == "Stapler_Metal" || currentCollider.gameObject.name == "Stapler_Top")
				{
					GUI.Box(new Rect(1200, 40, 200, 30), "Staple Some Papers Together");
				}
				else if(currentCollider.gameObject.name == "Laptop" || currentCollider.gameObject.name == "Laptop_Screen" || currentCollider.gameObject.name == "Laptop_Bottom")
				{
					GUI.Box(new Rect(1200, 40, 200, 30), "Browse Wikipedia");
				}
				else{
					GUI.Box(new Rect(1200, 40, 200, 30), " ");
				}            
			}

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

    /*void dropObject()
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
    }*/
}
