using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WPMTracker : MonoBehaviour
{

    public int completedCharacters = 0; 
    public int lastCompletedCharacters = 0;
    public int charactersWrong = 0;
    public TextMeshProUGUI WPMOnScreen;
    public TextMeshProUGUI WPMOnGameOver;

    public float WPM;

    private float currentTimePassed;

    private float startTime;
    public bool keepTrack = false;
    private bool hasStartedTrack = false;

    private float fiveSecInterval;
    private float saveTime = 0;

    // Start is called before the first frame update
    void Start()
    {
        WPMOnScreen = GameObject.FindGameObjectWithTag("WPMText").GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {

        if(!keepTrack && !hasStartedTrack)
        {
            startTime = Time.time;
        }


        if (keepTrack == true)
        {
            currentTimePassed = Time.time - startTime;
            fiveSecInterval = Time.time - startTime;
            if(fiveSecInterval - saveTime >= 5)
            {
                saveTime = fiveSecInterval;
                WPMOnScreen.text = calculateWPM() + " WPM";
                WPMOnGameOver.text = WPMOnScreen.text;

                fiveSecInterval = 0;
            }
            hasStartedTrack = true;
        }

    }

    void updateCompletedCharactersText()
    {
        if (lastCompletedCharacters != completedCharacters)
        {
            lastCompletedCharacters = completedCharacters;
            // Update UI
            WPMOnScreen.text = completedCharacters + " Completed Chars";
        }
    }

    string calculateWPM()
    {
        WPM = (completedCharacters / 5) / (currentTimePassed / 60);
        return WPM.ToString("F1");
    }
}
