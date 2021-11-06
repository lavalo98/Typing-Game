using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackEnemyMovement : MonoBehaviour
{

    public GameObject[] ballAudio;
    public AudioSource playSound;

    private int randomSound;

    public float Animation;

    public projectileSpawner projectile;

    public GameObject enemyToKill;

    public int randomEnemy;

    // Start is called before the first frame update
    void Awake()
    {
        projectile = GameObject.FindGameObjectWithTag("ProjectileSpawner").GetComponent<projectileSpawner>();

        randomSound = Random.Range(0, 3);

        ballAudio = GameObject.FindGameObjectsWithTag("AttackSound");

        playSound = ballAudio[randomSound].GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyToKill != null) {
            transform.LookAt(enemyToKill.transform);
            Animation += Time.deltaTime;
            Animation = Animation % 5;
            transform.position = MathParabola.Parabola(new Vector3(0, 4, 0), enemyToKill.transform.position, 5f, Animation * 2f);
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
