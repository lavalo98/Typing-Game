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

    IEnumerator resetLevel() {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("Level01");
    }

    public void backToMainMenuFromLevel()
    {
        StartCoroutine(backToMain());
    }

    public void resetLevelFromMenu() {
        StartCoroutine(resetLevel());
    }
}
