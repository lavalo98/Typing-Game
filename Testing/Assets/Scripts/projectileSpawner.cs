using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileSpawner : MonoBehaviour
{
    public GameObject projectile;
    public GameObject[] markedEnemies;
    public attackEnemyMovement attack;
    public void spawnProjectile() {
            Instantiate(projectile, new Vector3(0, 4, 0), Quaternion.identity);
            projectile.tag = "Projectile";
    }

    // Start is called before the first frame update
    void Start(){

    }

    // Update is called once per frame
    void Update(){
        markedEnemies = GameObject.FindGameObjectsWithTag("Marked for death");
        while (markedEnemies.Length != 0) {
            spawnProjectile();
            attack.enemyToKill = markedEnemies[0];
        }
    }

}
