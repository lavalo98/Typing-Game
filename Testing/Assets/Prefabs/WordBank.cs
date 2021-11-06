using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;
using System.Diagnostics;

public class WordBank : MonoBehaviour
{
    int rand100;

    public WordDiffucultyCalc checkDiff;

    private float wordDiffuculty;

    private float currentDifficulty;

    public string[] listOfUseableWords;

    string newWord = string.Empty;

    public List<List<string>> listOfWordLists = new List<List<string>>(); // List of where the words are written to
    
    

    private List<string> originalWords = new List<string>()
    {

    };

    private List<string> workingWords = new List<string>();

    public void putWordsIntoArray()
    { 
        Stopwatch st = new Stopwatch();
        st.Start();

        string oneCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "oneCharWords" + ".txt";
        string twoCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "twoCharWords" + ".txt";
        string threeCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "threeCharWords" + ".txt";
        string fourCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "fourCharWords" + ".txt";
        string fiveCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "fiveCharWords" + ".txt";
        string sixCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "sixCharWords" + ".txt";
        string sevenCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "sevenCharWords" + ".txt";
        string eightWordPath = Application.streamingAssetsPath + "/Recall_Words/" + "eightCharWords" + ".txt";
        string nineCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "nineCharWords" + ".txt";
        string tenCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "tenCharWords" + ".txt";
        string elevenCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "elevenCharWords" + ".txt";
        string twelveCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "twelveCharWords" + ".txt";
        string thirteenCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "thirteenCharWords" + ".txt";
        string fourteenCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "fourteenCharWords" + ".txt";
        string fifteenCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "fifteenCharWords" + ".txt";
        string sixteenCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "sixteenCharWords" + ".txt";
        string seventeenCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "seventeenCharWords" + ".txt";
        string eighteenCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "eighteenCharWords" + ".txt";
        string nineteenCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "nineteenCharWords" + ".txt";
        string twentyCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "twentyCharWords" + ".txt";
        string twentyOneCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "twentyOneCharWords" + ".txt";
        string twentyTwoCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "twentyTwoCharWords" + ".txt";
        string twentyThreeCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "twentyThreeCharWords" + ".txt";
        string twentyFourCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "twentyFourCharWords" + ".txt";
        string twentyFiveCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "twentyFiveCharWords" + ".txt";
        string twentySevenCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "twentySevenCharWords" + ".txt";
        string twentyEightCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "twentyEightCharWords" + ".txt";
        string twentyNineCharPath = Application.streamingAssetsPath + "/Recall_Words/" + "twentyNineCharWords" + ".txt";

        List<string> oneCharWords = File.ReadAllLines(oneCharPath).ToList();
        List<string> twoCharWords = File.ReadAllLines(twoCharPath).ToList();
        List<string> threeCharWords = File.ReadAllLines(threeCharPath).ToList();
        List<string> fourCharWords = File.ReadAllLines(fourCharPath).ToList();
        List<string> fiveCharWords = File.ReadAllLines(fiveCharPath).ToList();
        List<string> sixCharWords = File.ReadAllLines(sixCharPath).ToList();
        List<string> sevenCharWords = File.ReadAllLines(sevenCharPath).ToList();
        List<string> eightCharWords = File.ReadAllLines(eightWordPath).ToList();
        List<string> nineCharWords = File.ReadAllLines(nineCharPath).ToList();
        List<string> tenCharWords = File.ReadAllLines(tenCharPath).ToList();
        List<string> elevenCharWords = File.ReadAllLines(elevenCharPath).ToList();
        List<string> twelveCharWords = File.ReadAllLines(twelveCharPath).ToList();
        List<string> thirteenCharWords = File.ReadAllLines(thirteenCharPath).ToList();
        List<string> fourteenCharWords = File.ReadAllLines(fourteenCharPath).ToList();
        List<string> fifteenCharWords = File.ReadAllLines(fifteenCharPath).ToList();
        List<string> sixteenCharWords = File.ReadAllLines(sixteenCharPath).ToList();
        List<string> seventeenCharWords = File.ReadAllLines(seventeenCharPath).ToList();
        List<string> eighteenCharWords = File.ReadAllLines(eighteenCharPath).ToList();
        List<string> nineteenCharWords = File.ReadAllLines(nineteenCharPath).ToList();
        List<string> twentyCharWords = File.ReadAllLines(twentyCharPath).ToList();
        List<string> twentyOneCharWords = File.ReadAllLines(twentyOneCharPath).ToList();
        List<string> twentyTwoCharWords = File.ReadAllLines(twentyTwoCharPath).ToList();
        List<string> twentyThreeCharWords = File.ReadAllLines(twentyThreeCharPath).ToList();
        List<string> twentyFourCharWords = File.ReadAllLines(twentyFourCharPath).ToList();
        List<string> twentyFiveCharWords = File.ReadAllLines(twentyFiveCharPath).ToList();
        List<string> twentySevenCharWords = File.ReadAllLines(twentySevenCharPath).ToList();
        List<string> twentyEightCharWords = File.ReadAllLines(twentyEightCharPath).ToList();
        List<string> twentyNineCharWords = File.ReadAllLines(twentyNineCharPath).ToList();

        listOfWordLists.Add(oneCharWords);
        listOfWordLists.Add(twoCharWords);
        listOfWordLists.Add(threeCharWords);
        listOfWordLists.Add(fourCharWords);
        listOfWordLists.Add(fiveCharWords);
        listOfWordLists.Add(sixCharWords);
        listOfWordLists.Add(sevenCharWords);
        listOfWordLists.Add(eightCharWords);
        listOfWordLists.Add(nineCharWords);
        listOfWordLists.Add(tenCharWords);
        listOfWordLists.Add(elevenCharWords);
        listOfWordLists.Add(twelveCharWords);
        listOfWordLists.Add(thirteenCharWords);
        listOfWordLists.Add(fourteenCharWords);
        listOfWordLists.Add(fifteenCharWords);
        listOfWordLists.Add(sixteenCharWords);
        listOfWordLists.Add(seventeenCharWords);
        listOfWordLists.Add(eighteenCharWords);
        listOfWordLists.Add(nineteenCharWords);
        listOfWordLists.Add(twentyCharWords);
        listOfWordLists.Add(twentyOneCharWords);
        listOfWordLists.Add(twentyTwoCharWords);
        listOfWordLists.Add(twentyThreeCharWords);
        listOfWordLists.Add(twentyFourCharWords);
        listOfWordLists.Add(twentyFiveCharWords);
        listOfWordLists.Add(twentySevenCharWords);
        listOfWordLists.Add(twentyEightCharWords);
        listOfWordLists.Add(twentyNineCharWords);

        st.Stop();
        //UnityEngine.Debug.Log(string.Format("MyMethod took {0} ms to complete", st.ElapsedMilliseconds));
    }

    public void chooseRandomWordByCharLength()
    {
        int random = Random.Range(0, 27);
        workingWords = listOfWordLists[random];
    }

    public void chooseRandomWordFrom1to2CharLength()
    {
        int random = Random.Range(1, 1);
        workingWords = listOfWordLists[random];
    }

    public void chooseRandomWordFrom3to4CharLength()
    {
        int random = Random.Range(2, 3);
        workingWords = listOfWordLists[random];
    }

    public void chooseRandomWordFrom5to6CharLength()
    {
        int random = Random.Range(4, 5);
        workingWords = listOfWordLists[random];
    }

    public void chooseRandomWordFrom7to9CharLength()
    {
        int random = Random.Range(6, 8);
        workingWords = listOfWordLists[random];
    }

    public void chooseRandomWordFrom10to11CharLength()
    {
        int random = Random.Range(9, 10);
        workingWords = listOfWordLists[random];
    }

    public void chooseRandomWordFrom12to13CharLength()
    {
        int random = Random.Range(11, 12);
        workingWords = listOfWordLists[random];
    }

    public void chooseRandomWordFrom14to15CharLength()
    {
        int random = Random.Range(13, 14);
        workingWords = listOfWordLists[random];
    }

    public void chooseRandomWordFrom21to29CharLength()
    {
        int random = Random.Range(20, 28);
        workingWords = listOfWordLists[random];
    }

    void Awake()
    {
        putWordsIntoArray();
        chooseRandomWordByCharLength();
        workingWords.AddRange(originalWords);
        shuffle(workingWords);
        convertToLower(workingWords);
    }

    private void Update()
    {
        
    }

    private void shuffle(List<string> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            int random = Random.Range(i, list.Count);
            string temp = list[i];

            list[i] = list[random];
            list[random] = temp;
        }
    }

    private void convertToLower(List<string> list)
    {
        for(int i = 0; i < list.Count; i++)
        {
            list[i] = list[i].ToLower();
        }
    }

    private void random100()
    {
        rand100 = Random.Range(0,100);
    }

    public string getWord()
    {
        newWord = string.Empty;

    Start:

        random100();

        if(rand100 <= 2) // 2% Chance
        {
            chooseRandomWordFrom14to15CharLength();
        }
        else if (rand100 <= 6 && rand100 > 2) // 4% Chance
        {
            chooseRandomWordFrom12to13CharLength();
        }
        else if (rand100 <= 15 && rand100 > 6) // 9% Chance
        {
            chooseRandomWordFrom10to11CharLength();
        }
        else if (rand100 <= 30 && rand100 > 15) // 15% Chance
        {
            chooseRandomWordFrom7to9CharLength();
        }
        else if (rand100 <= 50 && rand100 > 30) // 20% Chance
        {
            chooseRandomWordFrom5to6CharLength();
        }
        else if (rand100 <= 70 && rand100 > 50) // 20% Chance
        {
            chooseRandomWordFrom3to4CharLength();
        }
        else if (rand100 <= 100 && rand100 > 70) // 25% Chance
        {
            chooseRandomWordFrom1to2CharLength();
        }

        shuffle(workingWords);

        if (workingWords.Count != 0)
        {
            newWord = workingWords.Last();
            currentDifficulty = GameObject.FindGameObjectWithTag("DiffucultyScaler").GetComponent<DifficultyScaler>().baseDifficulty;
            wordDiffuculty = GameObject.FindGameObjectWithTag("WordDifficultyChecker").GetComponent<WordDiffucultyCalc>().calculateDifficulty(newWord);
            if (wordDiffuculty > currentDifficulty)
            {
                UnityEngine.Debug.Log("Word Denied! Too Hard: " + newWord + "     " + wordDiffuculty + " > " + currentDifficulty);
                goto Start;
            }
            workingWords.Remove(newWord);
        }

        return newWord;
    }



}
