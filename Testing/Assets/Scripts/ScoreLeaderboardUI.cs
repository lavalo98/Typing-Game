using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreLeaderboardUI : MonoBehaviour
{
    public RowUI rowUi;
    void Start()
    {
        GameObject.FindGameObjectWithTag("PlayFab").GetComponent<PlayFabManager>().GetLeaderboard();
    }
}
