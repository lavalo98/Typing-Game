using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOverKillEnemy : MonoBehaviour
{

    public ParticleSystem enemyDeathParticles;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void selfDestruct()
    {
        Instantiate(enemyDeathParticles, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
