﻿using UnityEngine;
using System.Collections;

public class QuestTracker : MonoBehaviour
{
    public static bool internet = false;
    public static bool sleep = false;
    public static bool shit = false;
    public static bool phone = false;
    public static bool study = false;
    public string questCompleted = " - Completed";
    public string questOne = "Internet";
    public string questTwo = "Sleep";
    public string questThree = "Shit";
    public string questFour = "Pick Up Phone";
    public string questFive = "Study";
    public string questOneOriginalText = "Internet";
    public string questTwoOriginalText = "Sleep";
    public string questThreeOriginalText = "Shit";
    public string questFourOriginalText = "Pick Up Phone";
    public string questFiveOriginalText = "Study";

    // Update is called once per frame
    void Update()
    {
        if (internet == true && questOne != questOneOriginalText + questCompleted)
        {
            questOne = questOne + questCompleted;
        }
        else if (sleep == true && questTwo != questTwoOriginalText + questCompleted)
        {
            questTwo = questTwo + questCompleted;
        }
        else if (shit == true && questThree != questThreeOriginalText + questCompleted)
        {
            questThree = questThree + questCompleted;
        }
        else if (phone == true && questFour != questFourOriginalText + questCompleted)
        {
            questFour = questFour + questCompleted;

        }
        else if (study == true && questFive != questFiveOriginalText + questCompleted)
        {
            questFive = questFive + questCompleted;
        }
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 50, 200, 500), questOne + "\n" + questTwo + "\n" + questThree + "\n" + questFour + "\n" + questFive);
    }

}
