using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TwoTyperForMain : MonoBehaviour
{
    public WordBankForMainMenu wordBank = null;
    public TextMeshProUGUI wordOutput = null;
    public TextMeshProUGUI secondOutput = null;
    private string coloredLetter = null;
    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;
    private string secondWord = string.Empty;
    private string displayWord = string.Empty;
    public Destroyer myDestroyer;
    private int charIndex = 1;
    public int charWrong = 0;
    private int secondWordCheck = 0;
    private int wordScore = 0;
    private string wrongLetters;
    private int cumulativeScore;

    // Start is called before the first frame update
    private void Start()
    {
        FloatingTextController.Initialize();
        setSecondWord();
        setCurrentWord();
    }

    private void setSecondWord()
    {
        secondWord = wordBank.getWord();
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
        secondOutput.text = secondWord;
    }

    private void setSecondDisplayWord(string newString)
    {
        displayWord = newString;
        secondOutput.text = displayWord;
    }

    // Update is called once per frame
    private void Update()
    {
        foreach (char letter in Input.inputString)
        {
            enterLetter(letter.ToString());
        }
    }

    private void checkInput()
    {

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
            if (charWrong >= 2 && secondWordCheck == 0)
            {
                setRemainingWord(currentWord);
                setDisplayWord(currentWord);
                charIndex = 1;
                charWrong = 0;
                wrongLetters = "";
                return;
            }
            else if (charWrong >= 2 && secondWordCheck == 1)
            {
                setRemainingWord(secondWord);
                setDisplayWord(secondWord);
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
        if (secondWordCheck == 0)
        {
            coloredLetter = "<color=#000000>" + currentWord.Substring(0, charIndex) + "</color>";
            string newString = remainingWord.Remove(0, 1);
            setRemainingWord(newString);
            coloredLetter += newString;
            setDisplayWord(coloredLetter);
            charIndex++;
        }
        else
        {
            coloredLetter = "<color=#000000>" + secondWord.Substring(0, charIndex) + "</color>";
            string newString = remainingWord.Remove(0, 1);
            setRemainingWord(newString);
            coloredLetter += newString;
            setSecondDisplayWord(coloredLetter);
            charIndex++;
        }



    }

    public void resetCharWrong()
    {
        charWrong = 0;
    }


    public bool isWordComplete()
    {
        if (remainingWord.Length == 0)
        {
            if (secondWordCheck == 0)
            {
                wordScore = 10 * currentWord.Length;
                wordScore -= (10 * charWrong);
                cumulativeScore += wordScore;
                //Debug.Log("Base Word Score:" + wordScore + "     Length of word: " + currentWord.Length + "         charWrong" + charWrong);
                //Debug.Log("Letters typed wrong: " + wrongLetters);
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
                setRemainingWord(secondWord);
                secondWordCheck++;
                secondOutput.fontSize = 16;
                charIndex = 1;
                GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllOneCharWrong();
                GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllTwoCharWrong();
                GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllThreeCharWrong();
                return false;
            }
            wordScore = 10 * secondWord.Length;
            wordScore -= (10 * charWrong);
            cumulativeScore += wordScore;
            //Debug.Log("Base Word Score:" + wordScore + "     Length of word: " + secondWord.Length + "         charWrong" + charWrong);
            //Debug.Log("Letters typed wrong: " + wrongLetters);
            GameObject.FindGameObjectWithTag("Score Tracker").GetComponent<ScoreTracker>().beforeManipulationScore = cumulativeScore;
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
            GameObject.FindGameObjectWithTag("WPMTracker").GetComponent<WPMTracker>().completedCharacters += secondWord.Length;
            GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllOneCharWrong();
            GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllTwoCharWrong();
            GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllThreeCharWrong();
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
