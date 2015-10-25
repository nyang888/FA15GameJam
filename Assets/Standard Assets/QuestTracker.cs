using UnityEngine;
using System.Collections;

public class QuestTracker : MonoBehaviour {
    public static bool internet = false;
    public static bool sleep = false;
    public static bool shit = false;
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.Box(new Rect(10, 50, 200, 500), "Internet ("+" "+")\nSleep ("+" "+")\nShit ("+" "+")");
    }
}
