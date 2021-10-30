using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuToLevelSelect : MonoBehaviour
{
    Vector3 position = new Vector3(-31.54f, 5.26f, -103.8f);
    // Start is called before the first frame update
    void Start() {
        /*LeanTween.moveX(mainCamera.gameObject, -31.54f, 2).setEaseInOutQuad();
        LeanTween.moveY(mainCamera.gameObject, 5.26f, 2).setEaseInOutQuad();
        LeanTween.moveZ(mainCamera.gameObject, -103.8f, 2).setEaseInOutQuad();
        LeanTween.rotateX(mainCamera.gameObject, 15f, 2).setEaseInOutQuad();
        LeanTween.rotateY(mainCamera.gameObject, 0f, 2).setEaseInOutQuad();
        */
    }

    // Update is called once per frame
    void Update() {
        Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, position, Time.deltaTime);
    }
}
