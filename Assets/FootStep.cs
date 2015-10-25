using UnityEngine;
using System.Collections;

public class FootStep : MonoBehaviour {
    public static AudioSource audio;
    public static AudioClip audioClip;
	// Use this for initialization
	void Start () {
        audio.clip = audioClip;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButton("Vertical")   )  {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
        else
        {
            audio.Stop();
        }

        if (Input.GetButton("Horizontal"))
        {
            if (!audio.isPlaying)
            {
                audio.Play();
            }
        }
        else
        {
            audio.Stop();
        }
    }
}
