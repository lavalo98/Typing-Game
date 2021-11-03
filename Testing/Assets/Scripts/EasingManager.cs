using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasingManager : MonoBehaviour {

    public GameObject levelSelect1;
    public GameObject levelSelect2;
    public GameObject levelSelect3;
    public GameObject levelSelect4;
    public GameObject levelSelect5;
    public GameObject levelSelect6;
    public GameObject levelSelect7;
    public GameObject levelSelect8;
    public GameObject levelSelect9;
    public GameObject levelSelect10;

    // Start is called before the first frame update
    void Start() {
        LeanTween.moveY(levelSelect1, 6.44f, 2).setEaseInOutQuad().setLoopPingPong();
        LeanTween.moveY(levelSelect2, 6.44f, 2).setEaseInOutQuad().setLoopPingPong();
        LeanTween.moveY(levelSelect3, 6.44f, 2).setEaseInOutQuad().setLoopPingPong();
        LeanTween.moveY(levelSelect4, 6.44f, 2).setEaseInOutQuad().setLoopPingPong();
        LeanTween.moveY(levelSelect5, 6.44f, 2).setEaseInOutQuad().setLoopPingPong();
        LeanTween.moveY(levelSelect6, 4.94f, 2).setEaseInOutQuad().setLoopPingPong();
        LeanTween.moveY(levelSelect7, 4.94f, 2).setEaseInOutQuad().setLoopPingPong();
        LeanTween.moveY(levelSelect8, 4.94f, 2).setEaseInOutQuad().setLoopPingPong();
        LeanTween.moveY(levelSelect9, 4.94f, 2).setEaseInOutQuad().setLoopPingPong();
        LeanTween.moveY(levelSelect10, 4.94f, 2).setEaseInOutQuad().setLoopPingPong();
    }

    // Update is called once per frame
    void Update() {

    }
}