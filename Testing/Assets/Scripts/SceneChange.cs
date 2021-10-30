using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    public Animator transition;

    public float transitionTime = 0f;

    IEnumerator PlayTransitionLevel01() {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene("Level01");
    }

    public void PlayGameLevel01() {
        StartCoroutine(PlayTransitionLevel01());
    }

    void Update() {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out hit) && Input.GetMouseButton(0)) {
            if (hit.collider.name == "Level01") {
                PlayGameLevel01();
            }
        }
    }
}
