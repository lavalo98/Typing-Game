using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetCharWrongAll : MonoBehaviour
{
    public GameObject[] oneEnemies;
    public GameObject[] twoEnemies;
    public GameObject[] threeEnemies;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        oneEnemies = GameObject.FindGameObjectsWithTag("1 Word Enemy");
        twoEnemies = GameObject.FindGameObjectsWithTag("2 Word Enemy");
        threeEnemies = GameObject.FindGameObjectsWithTag("3 Word Enemy");
    }

    public void wipeAllOneCharWrong()
    {
        foreach (GameObject enemy in oneEnemies)
        {
            enemy.GetComponent<Typer>().resetCharWrong();
        }
    }

    public void wipeAllTwoCharWrong()
    {
        foreach (GameObject twoEnemy in twoEnemies)
        {
            twoEnemy.GetComponent<TwoWordTyper>().resetCharWrong();
        }
    }

    public void wipeAllThreeCharWrong()
    {
        foreach (GameObject threeEnemy in threeEnemies)
        {
            threeEnemy.GetComponent<threeWordTyper>().resetCharWrong();
        }
    }
}
