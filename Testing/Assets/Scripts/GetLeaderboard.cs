using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetLeaderboard : MonoBehaviour
{
    public void getLeaderboard()
    {
        GameObject.FindGameObjectWithTag("PlayFab").GetComponent<PlayFabManagerLevels>().GetLeaderboard();
    }
}
