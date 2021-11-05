using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Trigger : MonoBehaviour
{

    public Canvas gameOver;
    public Canvas wordLayer;
    public TextMeshProUGUI livesOnScreen;
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    public GameObject spawner4;
    private int scoreForLeaderboard;
    public int livesLeft;

    private void Start()
    {
        livesLeft = 3;
        livesOnScreen.text = livesLeft.ToString();
        gameObject.GetComponent<Collider>().enabled = false;
        gameObject.GetComponent<Collider>().enabled = true;
    }

    private void Update()
    {
        scoreForLeaderboard = GameObject.FindGameObjectWithTag("Score Tracker").GetComponent<ScoreTracker>().score;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(livesLeft > 1) {
            livesLeft--;
            Destroy(other.gameObject);
            livesOnScreen.text = livesLeft.ToString();
        }
        else {
            GameObject.FindGameObjectWithTag("WPMTracker").GetComponent<WPMTracker>().keepTrack = false;
            gameOver.gameObject.SetActive(true);
            wordLayer.gameObject.SetActive(false);
            spawner1.SetActive(false);
            spawner2.SetActive(false);
            spawner3.SetActive(false);
            spawner4.SetActive(false);
            GameObject.FindGameObjectWithTag("EnemyDespawner").GetComponent<DespawnEnemy>().wipeAllEnemy();
            GameObject.FindGameObjectWithTag("TimeTracker").GetComponent<TimeTracker>().playerDead = true;
            GameObject.FindGameObjectWithTag("PlayFab").GetComponent<PlayFabManagerLevels>().SendLeaderboard(scoreForLeaderboard);
        }
        
    }
}