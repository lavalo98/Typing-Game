using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform[] views;
    public float transitionSpeed;
    public Transform currentView;

    // Start is called before the first frame update
    void Start()
    {
        currentView = views[0];
    }

    private void Update() {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //Lerp Position
        transform.position = Vector3.Lerp(transform.position, currentView.position, transitionSpeed * Time.deltaTime);
        //Lerp Rotation
        transform.rotation = Quaternion.Lerp(transform.rotation, currentView.rotation, transitionSpeed * Time.deltaTime);
    }
}
