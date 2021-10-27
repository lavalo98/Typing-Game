using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{

    public Animator transition;

    public float transitionTime = 0f;

    IEnumerator backToMain()
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("Main Menu");
    }

    public void backToMainMenuFromLevel()
    {
        StartCoroutine(backToMain());
    }
}
