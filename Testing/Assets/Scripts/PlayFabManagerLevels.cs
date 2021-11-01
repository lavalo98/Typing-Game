using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using System;
using UnityEngine.UIElements;
using TMPro;

public class PlayFabManagerLevels : MonoBehaviour
{
    public GameObject rowPrefab;
    public Transform rowsParent;

    // Start is called before the first frame update
    void Start() {
        Login();
    }

    void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void Login() {
        var request = new LoginWithCustomIDRequest {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true,
            InfoRequestParameters = new GetPlayerCombinedInfoRequestParams {
                GetPlayerProfile = true
            }
        };
        PlayFabClientAPI.LoginWithCustomID(request, OnSuccess, OnError);
    }

    void OnSuccess(LoginResult result) {
        Debug.Log("Successful login/account created!");
    }

    void OnError(PlayFabError error) {
        Debug.Log("Error while logging in/creating account!");
        Debug.Log(error.GenerateErrorReport());
    }

    public void SendLeaderboard(int score) {
        var request = new UpdatePlayerStatisticsRequest {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "ScoreLeaderboard",
                    Value = score
                }
            }
        };
        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result) {
        Debug.Log("Successfull Leaderboard Sent");
    }

    public void GetLeaderboard() {
        var request = new GetLeaderboardRequest {
            StatisticName = "ScoreLeaderboard",
            StartPosition = 0,
            MaxResultsCount = 100
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result) {
        foreach (Transform item in rowsParent) {
            Destroy(item.gameObject);
        }

        foreach (var item in result.Leaderboard) {

            GameObject newGo = Instantiate(rowPrefab, rowsParent);
            TextMeshProUGUI[] texts = newGo.GetComponentsInChildren<TextMeshProUGUI>();
            texts[0].text = (item.Position + 1).ToString();
            texts[1].text = item.DisplayName;
            texts[2].text = item.StatValue.ToString();

            Debug.Log(item.Position + " || " + item.PlayFabId + " || " + item.StatValue);
        }
    }
}
