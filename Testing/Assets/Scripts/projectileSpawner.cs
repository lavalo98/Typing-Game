using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileSpawner : MonoBehaviour
{
    public GameObject projectile;
    public GameObject[] markedEnemies;
    public GameObject[] spawnedProjectiles;
    public attackEnemyMovement attack;
    public void spawnProjectile() {
            Instantiate(projectile, new Vector3(0, 4, 0), Quaternion.identity);
            projectile.tag = "Projectile";
    }

    // Start is called before the first frame update
    void Start(){

    }

    public int findIndexOf(GameObject[] a, GameObject b) {
        int counter = 0;
        foreach(GameObject item in a){
            if(item == b) {
                return counter;
            }
            counter++;
        }
        return 0;
    }

    // Update is called once per frame
    void Update(){
        markedEnemies = GameObject.FindGameObjectsWithTag("Marked for death");
        spawnedProjectiles = GameObject.FindGameObjectsWithTag("Projectile");
    }

}
