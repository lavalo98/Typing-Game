using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public int score;

    public TextMeshProUGUI scoreDisplay;

    public TextMeshProUGUI gameOverScoreDisplay;

    public TextMeshProUGUI wordMultiplier;

    public int wordStreak;

    public int wordMult;

    public int beforeManipulationScore;

    public int manipWordCheck;

    public int popUpTextPoints;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        wordMult = 1;
        wordStreak = 0;
        beforeManipulationScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreDisplay.text = "Score: " + score;
        wordMultiplier.text = "x" + wordMult;
        gameOverScoreDisplay.text = scoreDisplay.text;
    }

    public int scoreFromWordAfterManipulation(int beforeManip)
    {
        if(beforeManip >= 2 && beforeManip < 4)
        {
            wordMult = 2;
            return addToScore(beforeManipulationScore * 2);
        }
        else if (beforeManip >= 4 && beforeManip < 8)
        {
            wordMult = 3;
            return addToScore(beforeManipulationScore * 3);
        }
        else if (beforeManip >= 8 && beforeManip < 15)
        {
            wordMult = 4;
            return addToScore(beforeManipulationScore * 4);
        }
        else if (beforeManip >= 15 && beforeManip < 20)
        {
            wordMult = 5;
            return addToScore(beforeManipulationScore * 5);
        }
        else if (beforeManip >= 20) {
            wordMult = 6;
            return addToScore(beforeManipulationScore * 5);
        }
        wordMult = 1;
        return addToScore(beforeManipulationScore);
    }

    public int addToScore(int manipWordScore)
    {
        score += manipWordScore;
        popUpTextPoints = manipWordScore;
        return score;
    }
}
