using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemies;
    public string enemyString;
    public Vector3 spawnValues;
    public float spawnWait;
    public float spawnMostWait;
    public float spawnLeastWait;
    public int startWait;
    public bool stop;
    private bool firstEnemySpawn = false;

    int randEnemy;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(waitSpawner());
    }

    // Update is called once per frame
    void Update()
    {
        spawnWait = Random.Range(spawnLeastWait, spawnMostWait);
    }

    IEnumerator waitSpawner()
    {
        yield return new WaitForSeconds(startWait);

        while (!stop)
        {

            if(firstEnemySpawn == false)
            {
                GameObject.FindGameObjectWithTag("WPMTracker").GetComponent<WPMTracker>().keepTrack = true;
            }

            randEnemy = Random.Range(0,4);

            Vector3 spawnPositon = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), 1, Random.Range(-spawnValues.z, spawnValues.z));

            Instantiate(enemies[randEnemy], spawnPositon + transform.TransformPoint(0,0,0), gameObject.transform.rotation);

            firstEnemySpawn = true;

            yield return new WaitForSeconds(spawnWait);
        }
    }
}
