using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hitEnemy : MonoBehaviour
{

    public float speed = 0.001f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveFireball(new Vector3(1,0,1));
    }

    void moveFireball(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
