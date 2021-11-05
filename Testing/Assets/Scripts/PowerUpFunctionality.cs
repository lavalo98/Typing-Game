using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFunctionality : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnMouseDown() {
        if(gameObject.tag == "SlowdownPowerUp") {
            Destroy(gameObject);
            Debug.Log("Activate Slow Down PowerUp");
        }
        if (gameObject.tag == "Nuke") {
            Destroy(gameObject);
            Debug.Log("Activate Nuke PowerUp");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
