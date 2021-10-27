using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class projectileSpawner : MonoBehaviour
{
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Projectile") == null)
        {
            Instantiate(projectile, new Vector3(0,4,0), Quaternion.identity);
            projectile.tag = "Projectile";
        }
    }

}
