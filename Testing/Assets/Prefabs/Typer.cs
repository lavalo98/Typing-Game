using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class Typer : MonoBehaviour
{

    public WordBank wordBank = null;
    public WPMTracker WPMTracker = null;
    public TextMeshProUGUI wordOutput = null;
    private string coloredLetter = null;
    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;
    private string displayWord = string.Empty;
    public Destroyer myDestroyer;
    public TypingSoundsManager clickSound;
    public NavMeshAgent agent;
    private int charIndex = 1;
    private int charWrong = 0;
    private int wordScore = 0;
    string wrongLetters;

    // Start is called before the first frame update
    private void Start() {
        setCurrentWord();
        FloatingTextController.Initialize();
    }

    private void setCurrentWord()
    {
        currentWord = wordBank.getWord();
        setRemainingWord(currentWord);
        setDisplayWord(currentWord);
    }

    private void setRemainingWord(string newString)
    {
        remainingWord = newString;
    }

    private void setDisplayWord(string newString)
    {
        displayWord = newString;
        wordOutput.text = displayWord;
    }

    // Update is called once per frame
    private void Update() {
        foreach (char letter in Input.inputString)
        {
            enterLetter(letter.ToString());
        }
        //Debug.Log(charWrong);
    }

    private void enterLetter(string typedLetter)
    {
        if (correctLetter(typedLetter))
        {
            removeLetter();

            if (isWordComplete())
            {
                setCurrentWord();
            }
        }
        else
        {
            if (charWrong == 2)
            {
                setRemainingWord(currentWord);
                setDisplayWord(currentWord);
                charWrong = 0;
                charIndex = 1;
                wrongLetters = "";
                return;
            }
                wrongLetters += typedLetter;
                charWrong++;

        }
    }

    private bool correctLetter(string letter)
    {
        return remainingWord.IndexOf(letter) == 0;
    }

    private void removeLetter()
    {
        clickSound.Play = true;
        clickSound.playClick();
        clickSound.Play = false;
        coloredLetter = "<color=#000000>" + currentWord.Substring(0,charIndex) + "</color>";
        string newString = remainingWord.Remove(0, 1);
        setRemainingWord(newString);
        coloredLetter += newString;
        setDisplayWord(coloredLetter);
        charIndex++;
    }

    public void resetCharWrong()
    {
        charWrong = 0;
    }

    private void keepScore()
    {
        wordScore = 10 * currentWord.Length;
        wordScore -= (10 * charWrong);
        //Debug.Log("Base Word Score: " + wordScore + "     Length of word: " + currentWord.Length + "         charWrong" + charWrong);
        //Debug.Log("Letters typed wrong: " + wrongLetters);
        GameObject.FindGameObjectWithTag("Score Tracker").GetComponent<ScoreTracker>().beforeManipulationScore = wordScore;
        GameObject.FindGameObjectWithTag("Score Tracker").GetComponent<ScoreTracker>().scoreFromWordAfterManipulation(GameObject.FindGameObjectWithTag("Score Tracker").GetComponent<ScoreTracker>().wordStreak);
        if (charWrong == 0)
        {
            GameObject.FindGameObjectWithTag("Score Tracker").GetComponent<ScoreTracker>().wordStreak++;
        }
        else
        {
            GameObject.FindGameObjectWithTag("Score Tracker").GetComponent<ScoreTracker>().wordStreak = 0;
        }
        GameObject.FindGameObjectWithTag("WPMTracker").GetComponent<WPMTracker>().charactersWrong += charWrong;
        GameObject.FindGameObjectWithTag("WPMTracker").GetComponent<WPMTracker>().completedCharacters += currentWord.Length;
    }

    IEnumerator stunEnemy() {
        agent.speed = 0f;
        yield return new WaitForSeconds(.5f);
        agent.speed = .5f;
    }

    public void stunEnemyUse() {
        StartCoroutine(stunEnemy());
    }

    public bool isWordComplete()
    {
        if(remainingWord.Length == 0)
        {
            keepScore();
            gameObject.tag = "Marked for death";
            GameObject.FindGameObjectWithTag("Projectile").GetComponent<attackEnemyMovement>().playAudio();
            return false;
        }
        else
        {
            return false;
        }
    }

}

