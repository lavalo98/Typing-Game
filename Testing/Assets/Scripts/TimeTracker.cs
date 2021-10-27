using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimeTracker : MonoBehaviour
{

    public float timeElapsed;

    public float startTime;

    public bool playerDead = false;

    public TextMeshProUGUI timerOnScreen;

    public TextMeshProUGUI timerOnGameOver;

    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerDead)
        {
            timeElapsed = Time.time - startTime;
            //Debug.Log("Time Elapsed: " + timeElapsed);
            timerOnScreen.text = keepTrackNiceTime();
            timerOnGameOver.text = "Time Elapsed: " + keepTrackNiceTime();
        }        
    }

    public string keepTrackNiceTime()
    {
        int minutes = Mathf.FloorToInt(timeElapsed / 60F);
        int seconds = Mathf.FloorToInt(timeElapsed - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        return niceTime;
    }
}
