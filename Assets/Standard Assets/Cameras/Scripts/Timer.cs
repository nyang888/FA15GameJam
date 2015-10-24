using UnityEngine;
using System.Collections;
using System;

public class Timer : MonoBehaviour {

    public float seconds;
    public float minutes;
    public bool gameOverTriggered = false;
    public int intSeconds;
    public int intMinutes;
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
                    gameOver();
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
        GUI.Label(new Rect(10, 10, 1250, 20), "Time until the bed:");
        GUI.Box(new Rect(125, 10, 50, 20), intMinutes.ToString() + ":" + intSeconds.ToString());
    }

    void gameOver()
    {
        Debug.Log("Game Over");  
    }


}
