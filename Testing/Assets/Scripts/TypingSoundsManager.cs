using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingSoundsManager : MonoBehaviour
{

    public GameObject[] ballAudio;
    public AudioSource playSound;
    private int randomSound;
    public bool Play;

    // Start is called before the first frame update
    void Start()
    {
        Play = false;
    }

    public void playClick() {
        if(Play == true) {
            ballAudio = GameObject.FindGameObjectsWithTag("TypeSound");

            randomSound = Random.Range(0, 3);

            playSound = ballAudio[randomSound].GetComponent<AudioSource>();

            playSound.Play();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
