using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class TwoWordTyper : MonoBehaviour
{
    public WordBank wordBank = null;
    public TextMeshProUGUI wordOutput = null;
    private string coloredLetter = null;
    private string remainingWord = string.Empty;
    private string currentWord = string.Empty;
    private string secondWord = string.Empty;
    private string displayWord = string.Empty;
    public Destroyer myDestroyer;
    public NavMeshAgent agent;
    public TypingSoundsManager clickSound;
    public float health = 100f;
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
            clickSound.Play = true;
            clickSound.playClick();
            clickSound.Play = false;
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
            coloredLetter = "<color=#000000f0>" + currentWord.Substring(0, charIndex) + "</color>";
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

    IEnumerator stunEnemy() {
        agent.speed = 0f;
        yield return new WaitForSeconds(.9f);
        agent.speed = .5f;
    }

    public void stunEnemyUse() {
        StartCoroutine(stunEnemy());
    }


    public bool isWordComplete()
    {
        if (remainingWord.Length == 0)
        {
            if(secondWordCheck == 0) 
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
                currentWord = secondWord;
                secondWordCheck++;
                wordOutput.text = secondWord;
                charIndex = 1;
                health -= 50f;
                GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllOneCharWrong();
                GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllTwoCharWrong();
                GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllThreeCharWrong();
                stunEnemyUse();
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
            health -= 50f;
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
