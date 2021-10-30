using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHoverLook : MonoBehaviour {

    // Start is called before the first frame update
    void OnMouseEnter() {
        //transform.LookAt(cam.transform); // or whatever roatation you want
    }
    // to reset:
    void OnMouseExit() {
        
    }
}
