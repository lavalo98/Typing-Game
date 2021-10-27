using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuTextTransition : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public Button optionsButton;
    public Button playButton;
    public Button quitButton;
    public Button backButton;
    public TextMeshProUGUI optionsHeader;
    public Button volume;
    public Slider volumeSlider;

    void Start()
    {
        // We are adding a listener so our method will be called when button is clicked
        optionsButton.onClick.AddListener(Button1Clicked);
        backButton.onClick.AddListener(Button2Clicked);
    }

    public void Button1Clicked()
    {
        //This method will be called when button1 is clicked 
        //Do whatever button 1 does
        playButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        StartCoroutine(ButtonDelay1());
    }

    public void Button2Clicked()
    {
        //This method will be called when button1 is clicked 
        //Do whatever button 1 does
        optionsMenu.gameObject.SetActive(false);
        StartCoroutine(ButtonDelay2());
    }

    IEnumerator ButtonDelay1()
    {
        yield return new WaitForSeconds(1f);

        // This line will be executed after 10 seconds passed
        optionsMenu.gameObject.SetActive(true);
    }

    IEnumerator ButtonDelay2()
    {
        yield return new WaitForSeconds(1f);

        // This line will be executed after 10 seconds passed
        playButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
    }
}
