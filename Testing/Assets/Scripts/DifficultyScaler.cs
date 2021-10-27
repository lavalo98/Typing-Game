using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyScaler : MonoBehaviour
{

    public bool playerDead = false;
    public float baseDifficulty = 3;
    
    private float timeElapsed;
    private float startTime;

    // Start is called before the first frame update
    void Start()
    {
        startTime = GameObject.FindGameObjectWithTag("TimeTracker").GetComponent<TimeTracker>().startTime;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed = GameObject.FindGameObjectWithTag("TimeTracker").GetComponent<TimeTracker>().timeElapsed;

        if (timeElapsed - startTime >= 10)
        {
            startTime = timeElapsed;
            scalerCalculations();

        }
    }

    public void scalerCalculations()
    {
        baseDifficulty *= 1.04f;
        Debug.Log(baseDifficulty);
    }
}
