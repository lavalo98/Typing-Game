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

    private void Start()
    {
        mainMenuObjects = GameObject.FindGameObjectsWithTag("MenuEnemy");  
    }

    IEnumerator PlayTransition()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("Level01");
    }

    IEnumerator ToOptions()
    {
        options.SetFloat("Speed", 1.0f);
        options.PlayInFixedTime("cameraTransitionNewMenu",-1,0);
        lightAnimator.SetFloat("Speed", 1.0f);
        lightAnimator.PlayInFixedTime("dayToNight",-1,0);

        yield return new WaitForSeconds(.2f);

        foreach (GameObject a in mainMenuObjects)
        {
            if (a.activeSelf == false)
            {
                a.SetActive(true);
            }

            if (a.activeSelf == true){
                a.SetActive(false);
            }
        }

        foreach (GameObject a in optionsMenuObjects)
        {
            if (a.activeSelf == false)
            {
                a.SetActive(true);
            }
            else
            {
                a.SetActive(false);
            }
        }
    }

    IEnumerator BackToMain()
    {
        options.SetFloat("Speed", -1.0f);
        options.PlayInFixedTime("cameraTransitionNewMenu", -1, 1);
        lightAnimator.SetFloat("Speed", -1.0f);
        lightAnimator.PlayInFixedTime("dayToNight", -1, 1);

        yield return new WaitForSeconds(.2f);

        foreach (GameObject a in mainMenuObjects)
        {
            if (a.activeSelf == false)
            {
                a.SetActive(true);
            }
            else
            {
                a.SetActive(false);
            }
        }

        foreach (GameObject a in optionsMenuObjects)
        {
            if (a.activeSelf == false)
            {
                a.SetActive(true);
            }
            else
            {
                a.SetActive(false);
            }
        }
    }

    public void PlayGame()
    {
        StartCoroutine(PlayTransition());
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
