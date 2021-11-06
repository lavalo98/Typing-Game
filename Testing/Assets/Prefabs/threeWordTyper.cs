using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class threeWordTyper : MonoBehaviour
{
    public WordBank wordBank;
    public TextMeshProUGUI wordOutput = null;
    private string coloredLetter = null;
    private string remainingWord = string.Empty;
    public string currentWord = string.Empty;
    private string secondWord = string.Empty;
    private string thirdWord = string.Empty;
    private string displayWord = string.Empty;
    public projectileSpawner projectile;
    public Destroyer myDestroyer;
    public TypingSoundsManager clickSound;
    public float health = 100f;
    public NavMeshAgent agent;
    private int charIndex = 1;
    public int charWrong = 0;
    private int wordCheck = 0;
    private int wordScore = 0;
    private int cumulativeScore;

    // Start is called before the first frame update
    private void Start()
    {
        projectile = GameObject.FindGameObjectWithTag("ProjectileSpawner").GetComponent<projectileSpawner>();
        wordBank = GameObject.FindGameObjectWithTag("WordBankManager").GetComponent<WordBank>();
        FloatingTextController.Initialize();
        setSecondWord();
        setThirdWord();
        setCurrentWord();
    }

    private void setSecondWord()
    {
        while (secondWord == string.Empty) {
            secondWord = wordBank.getWord();
        }
    }
    
    private void setThirdWord()
    {
        while (thirdWord == string.Empty) {
            thirdWord = wordBank.getWord();
        }
    }

    private void setCurrentWord()
    {
        while (currentWord == string.Empty) {
            currentWord = wordBank.getWord();
        }
        setRemainingWord(currentWord);
        setDisplayWord(currentWord);
    }

    public void resetCharWrong()
    {
        charWrong = 0;
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
            if (charWrong >= 2 && wordCheck == 0)
            {
                setRemainingWord(currentWord);
                setDisplayWord(currentWord);
                charWrong = 0;
                charIndex = 1;
                return;
            }
            else if (charWrong >= 2 && wordCheck == 1)
            {
                setRemainingWord(secondWord);
                setDisplayWord(secondWord);
                charWrong = 0;
                charIndex = 1;
                return;
            }
            else if (charWrong >= 2 && wordCheck == 2)
            {
                setRemainingWord(thirdWord);
                setDisplayWord(thirdWord);
                charWrong = 0;
                charIndex = 1;
                return;
            }
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
            if (wordCheck == 0)
            {
                wordScore = 10 * currentWord.Length;
                wordScore -= (10 * charWrong);
                cumulativeScore += wordScore;
                //Debug.Log("Base Word Score:" + wordScore + "     Length of word: " + currentWord.Length + "         charWrong" + charWrong);
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
                wordCheck++;
                wordOutput.text = secondWord;
                GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllOneCharWrong();
                GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllTwoCharWrong();
                GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllThreeCharWrong();
                charIndex = 1;
                charWrong = 0;
                health -= 34;
                stunEnemyUse();
                return false;
            }else if (wordCheck == 1)
            {
                wordScore = 10 * secondWord.Length;
                wordScore -= (10 * charWrong);
                cumulativeScore += wordScore;
                //Debug.Log("Base Word Score:" + wordScore + "     Length of word: " + secondWord.Length + "         charWrong" + charWrong);
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
                setRemainingWord(thirdWord);
                currentWord = thirdWord;
                wordCheck++;
                wordOutput.text = thirdWord;
                GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllOneCharWrong();
                GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllTwoCharWrong();
                GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllThreeCharWrong();
                charIndex = 1;
                charWrong = 0;
                health -= 33;
                stunEnemyUse();
                return false;
            }
            gameObject.tag = "Marked for death";
            wordScore = 10 * thirdWord.Length;
            wordScore -= (10 * charWrong);
            cumulativeScore += wordScore;
            //Debug.Log("Base Word Score:" + wordScore + "     Length of word: " + thirdWord.Length + "         charWrong" + charWrong);
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
            GameObject.FindGameObjectWithTag("WPMTracker").GetComponent<WPMTracker>().completedCharacters += thirdWord.Length;
            projectile.spawnProjectile();
            GameObject.FindGameObjectWithTag("Projectile").GetComponent<attackEnemyMovement>().playAudio();
            GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllOneCharWrong();
            GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllTwoCharWrong();
            GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllThreeCharWrong();
            health -= 33;
            return false;
        }
        else
        {
            return false;
        }
    }
}
