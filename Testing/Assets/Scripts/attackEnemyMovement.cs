using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackEnemyMovement : MonoBehaviour
{

    public GameObject[] ballAudio;
    public AudioSource playSound;

    private int randomSound;

    public float Animation;

    // Start is called before the first frame update
    void Start()
    {
        ballAudio = GameObject.FindGameObjectsWithTag("AttackSound");

        randomSound = Random.Range(0, 3);

        playSound = ballAudio[randomSound].GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Marked for death") != null)
        {
            transform.LookAt(GameObject.FindGameObjectWithTag("Marked for death").GetComponent<Transform>());

            Animation += Time.deltaTime;
            Animation = Animation % 5;
            transform.position = MathParabola.Parabola(new Vector3(0,4,0), GameObject.FindGameObjectWithTag("Marked for death").transform.position, 5f, Animation * 2f);
            //transform.position += transform.forward * 20f * Time.deltaTime;
        }
    }

    public void playAudio()
    {
        playSound.Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Marked for death")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
