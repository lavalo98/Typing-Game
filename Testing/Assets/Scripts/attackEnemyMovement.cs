using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attackEnemyMovement : MonoBehaviour
{

    public GameObject[] ballAudio;
    public AudioSource playSound;
    public projectileSpawner spawner;

    private int randomSound;

    public float Animation;

    // Start is called before the first frame update
    void Awake()
    {
        spawner = GameObject.FindGameObjectWithTag("ProjectileSpawner").GetComponent<projectileSpawner>();

        randomSound = Random.Range(0, 3);

        ballAudio = GameObject.FindGameObjectsWithTag("AttackSound");

        playSound = ballAudio[randomSound].GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        Animation += Time.deltaTime;
        Animation = Animation % 5;

        foreach (GameObject projectile in spawner.spawnedProjectiles) {
            if(gameObject == projectile) {
                if(spawner.markedEnemies[spawner.findIndexOf(spawner.spawnedProjectiles, gameObject)] != null) {
                    transform.LookAt(spawner.markedEnemies[spawner.findIndexOf(spawner.spawnedProjectiles, gameObject)].transform);
                    transform.position = MathParabola.Parabola(new Vector3(0, 4, 0), spawner.markedEnemies[spawner.findIndexOf(spawner.spawnedProjectiles, gameObject)].transform.position, 5f, Animation * 2f);
                }
                else {
                    Destroy(gameObject);
                }
            }
        }

        //transform.position = Vector3.MoveTowards(transform.position, targ.transform.position, .03);
        /*if (enemyToKill != null) {
            
            
            
        }*/
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
