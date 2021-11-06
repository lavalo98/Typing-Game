using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnEnemy : MonoBehaviour
{
    public GameObject[] oneEnemies;
    public GameObject[] twoEnemies;
    public GameObject[] threeEnemies;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        oneEnemies = GameObject.FindGameObjectsWithTag("1 Word Enemy");
        twoEnemies = GameObject.FindGameObjectsWithTag("2 Word Enemy");
        threeEnemies = GameObject.FindGameObjectsWithTag("3 Word Enemy");
    }

    IEnumerator waitSelfDestruct()
    {

        if(oneEnemies != null) {
            foreach (GameObject enemy in oneEnemies) {
                yield return new WaitForSeconds(.2f);
                enemy.GetComponent<gameOverKillEnemy>().selfDestruct();
            }
        }

        if (twoEnemies != null) {
            foreach (GameObject twoEnemy in twoEnemies) {
                yield return new WaitForSeconds(.2f);
                twoEnemy.GetComponent<gameOverKillEnemy>().selfDestruct();
            }
        }

        if (threeEnemies != null) {
            foreach (GameObject threeEnemy in threeEnemies) {
                yield return new WaitForSeconds(.2f);
                threeEnemy.GetComponent<gameOverKillEnemy>().selfDestruct();
            }
        }        
    }

    public void wipeAllEnemy()
    {
        StartCoroutine(waitSelfDestruct());
    }
}
