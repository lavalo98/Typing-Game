using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 5f;

    public Animator options;

    public Animator lightAnimator;

    public GameObject[] mainMenuObjects;
    public GameObject[] optionsMenuObjects;

    public CameraController mainCam;

    private void Start()
    {
       
    }

    IEnumerator ToOptions()
    {
        mainCam.currentView = mainCam.views[2];

        yield return new WaitForSeconds(0f);
    }

    IEnumerator BackToMain()
    {
        mainCam.currentView = mainCam.views[0];

        yield return new WaitForSeconds(0f);
    }

    IEnumerator ToLevelSelect() {
        mainCam.currentView = mainCam.views[1];

        yield return new WaitForSeconds(0f);
    }

    public void moveToLevelSelect() {
        StartCoroutine(ToLevelSelect());
    }

    public void setOptionsMenu()
    {
        StartCoroutine(ToOptions());
    }

    public void backToMainMenu()
    {
        StartCoroutine(BackToMain());
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
