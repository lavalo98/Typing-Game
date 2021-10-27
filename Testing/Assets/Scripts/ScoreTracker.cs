using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public int score;

    public TextMeshProUGUI scoreDisplay;

    public TextMeshProUGUI gameOverScoreDisplay;

    public int wordStreak;

    public int beforeManipulationScore;

    public int manipWordCheck;

    public int popUpTextPoints;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        wordStreak = 0;
        beforeManipulationScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "Score: " + score;
        gameOverScoreDisplay.text = scoreDisplay.text;
    }

    public int scoreFromWordAfterManipulation(int beforeManip)
    {
        if(beforeManip >= 5 && beforeManip < 10)
        {
            return addToScore(beforeManipulationScore * 2);
        }
        else if (beforeManip >= 10 && beforeManip < 15)
        {
            return addToScore(beforeManipulationScore * 3);
        }
        else if (beforeManip >= 15 && beforeManip < 20)
        {
            return addToScore(beforeManipulationScore * 4);
        }
        else if (beforeManip >= 20)
        {
            return addToScore(beforeManipulationScore * 5);
        }

        return addToScore(beforeManipulationScore);
    }

    public int addToScore(int manipWordScore)
    {
        score += manipWordScore;
        popUpTextPoints = manipWordScore;
        return score;
    }
}
