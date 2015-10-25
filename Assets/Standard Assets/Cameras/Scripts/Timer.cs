using UnityEngine;
using System.Collections;
using System;

public class Timer : MonoBehaviour {

    public float seconds;
    public float minutes;
    public bool gameOverTriggered = false;
    public static int intSeconds;
    public static int intMinutes;
    public bool showEnding = false;
    public bool internetTimeDeleted = false;
    public bool sleepTimeDeleted = false;
    public bool shitTimeDeleted = false;
    public bool phoneTimeDeleted = false;
    public bool stapleTimeDeleted = false;
    public bool studyTimeDeleted = false;
    
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
        if (QuestTracker.internet)
        {
            if (internetTimeDeleted == false)
            {
                minutes--;
                internetTimeDeleted = true;
            }
        }
        if (QuestTracker.sleep)
        {
            if (sleepTimeDeleted == false)
            {
                minutes--;
                sleepTimeDeleted = true;
            }
        }
        if (QuestTracker.shit)
        {
            if (shitTimeDeleted == false)
            {
                minutes--;
                shitTimeDeleted = true;
            }
        }
        if (QuestTracker.phone)
        {
            if (phoneTimeDeleted == false)
            {
                minutes--;
                phoneTimeDeleted = true;
            }
        }

        if (QuestTracker.staple)
        {
            if (stapleTimeDeleted == false)
            {
                minutes--;
                stapleTimeDeleted = true;
            }
        }
        if (QuestTracker.study)
        {
            if (studyTimeDeleted == false)
            {
                minutes--;
                studyTimeDeleted = true;
            }
        }
	}

    void OnGUI() {
        intSeconds = (int)Math.Ceiling(seconds);
        intMinutes = (int)Math.Ceiling(minutes);
        GUI.Label(new Rect(10, 10, 1250, 20), "Time until bed:");
        GUI.Box(new Rect(125, 10, 50, 20), intMinutes.ToString() + ":" + intSeconds.ToString());
        if (showEnding)
        {
            GUI.Box(new Rect(600, 250, 250, 50), "You run out of time!!! Game Over!");
        }
    }



}
