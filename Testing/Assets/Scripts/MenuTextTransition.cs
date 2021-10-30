using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MenuTextTransition : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject levelSelectMenu;
    public Button optionsButton;
    public Button playButton;
    public Button quitButton;
    public Button backButton;
    public Button levelSelectBackButton;
    public TextMeshProUGUI optionsHeader;
    public TextMeshProUGUI levelSelectHeader;
    public Button volume;
    public Slider volumeSlider;

    void Start()
    {
        // We are adding a listener so our method will be called when button is clicked
        optionsButton.onClick.AddListener(OptionsButtonClicked);
        backButton.onClick.AddListener(BackToMainButtonClicked);
        playButton.onClick.AddListener(PlayButtonClicked);
    }

    public void OptionsButtonClicked()
    {
        //This method will be called when button1 is clicked 
        //Do whatever button 1 does
        playButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        StartCoroutine(OptionsButton());
    }

    public void PlayButtonClicked() {
        //This method will be called when button1 is clicked 
        //Do whatever button 1 does
        playButton.gameObject.SetActive(false);
        quitButton.gameObject.SetActive(false);
        optionsButton.gameObject.SetActive(false);
        StartCoroutine(PlayButton());
    }

    public void BackToMainButtonClicked()
    {
        //This method will be called when button1 is clicked 
        //Do whatever button 1 does
        optionsMenu.gameObject.SetActive(false);
        levelSelectMenu.gameObject.SetActive(false);
        StartCoroutine(BackToMainButtonDelay());
    }

    IEnumerator OptionsButton()
    {
        yield return new WaitForSeconds(.7f);

        // This line will be executed after .7 seconds passed
        optionsMenu.gameObject.SetActive(true);
    }

    IEnumerator PlayButton() {
        yield return new WaitForSeconds(.9f);

        // This line will be executed after .7 seconds passed
        levelSelectMenu.gameObject.SetActive(true);
    }

    IEnumerator BackToMainButtonDelay()
    {
        yield return new WaitForSeconds(.7f);

        // This line will be executed after .7 seconds passed
        playButton.gameObject.SetActive(true);
        quitButton.gameObject.SetActive(true);
        optionsButton.gameObject.SetActive(true);
    }
}
