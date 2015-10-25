using UnityEngine;
using System.Collections;
using System;

public class Timer : MonoBehaviour {

    public float seconds;
    public float minutes;
    public bool gameOverTriggered = false;
    public int intSeconds;
    public int intMinutes;
    public bool showEnding = false;
	// Update is called once per frame
	void Update () {
        if (seconds <= 0)
        {
            if (minutes >= 1)
            {
                seconds = 60;
                minutes--;
            }
            else
            {
                if (gameOverTriggered == false)
                {
                    seconds = 0;
                    minutes = 0;
                    showEnding = true;
                    gameOverTriggered = true;
                }
            }
        }
        else {
            seconds -= Time.deltaTime;
        }
	}

    void OnGUI() {
        intSeconds = (int)Math.Ceiling(seconds);
        intMinutes = (int)Math.Ceiling(minutes);
        GUI.Label(new Rect(10, 10, 1250, 20), "Time until bed:");
        GUI.Box(new Rect(125, 10, 50, 20), intMinutes.ToString() + ":" + intSeconds.ToString());
        if (showEnding)
        {
            GUI.Box(new Rect(600, 300, 100, 50), "Game Over!");
        }
    }



}
