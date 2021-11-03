using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpMovement : MonoBehaviour
{

    // Start is called before the first frame update
    void Start() {
        LeanTween.moveY(gameObject, 3f, 2).setEaseInOutQuad().setLoopPingPong();
    }

    void OnMouseDown() {
        Destroy(gameObject);
        Debug.Log("Clciked");
    }

    // Update is called once per frame
    void Update() {
       
    }
}
