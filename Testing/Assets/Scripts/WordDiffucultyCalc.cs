using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordDiffucultyCalc : MonoBehaviour
{
    static char[,] KEYBOARD_ARRAY_2D = new char[,] { { 'q', 'w', 'e', 'r', 't', 'y', 'u', 'i', 'o', 'p'},
                                                     { 'a', 's' , 'd', 'f', 'g', 'h', 'j', 'k', 'l' , ' '}, 
                                                     { ' ', 'z', 'x', 'c', 'v', 'b', 'n', 'm', ' ', ' ' }};

    private void Start()
    {
    }

    public float calculateDifficulty(string a)
    {
        float difficultySlope = 0f;
        a = a.ToLower();
        for(int i = 0; i < a.Length-1; i++)
        {
            char currentLetter = a[i];
            char nextLetter = a[i+1];

            difficultySlope += (findSlopeBetweenLetters(findLocationOfLetter(currentLetter), findLocationOfLetter(nextLetter)) * a.Length) / 100;

            //Debug.Log("Current Letter Location: " + findLocationOfLetter(currentLetter) + "    Next Letter Location: " + findLocationOfLetter(nextLetter) + "DifficultySlope: " + difficultySlope);
            
        }
        //Debug.Log("Word: " + a.ToUpper());
        //Debug.Log("DifficultySlope: " + difficultySlope);
        return difficultySlope;
    }

    float findSlopeBetweenLetters(KeyValuePair<int, int> a, KeyValuePair<int, int> b)
    {
        float slope = 0f;

        slope = Mathf.Abs((a.Value - b.Value) - (a.Key - b.Key));

        return slope;
    }

    KeyValuePair<int,int> findLocationOfLetter(char a)
    {
        KeyValuePair<int, int> position;

        for (int x = 0; x < KEYBOARD_ARRAY_2D.GetLength(0); ++x)
        {
            for (int y = 0; y < KEYBOARD_ARRAY_2D.GetLength(1); ++y)
            {
                if (KEYBOARD_ARRAY_2D[x, y].Equals(a))
                {
                    position = new KeyValuePair<int, int>(x,y);
                    return position;
                }
            }
        }
        return position;
    }
}


