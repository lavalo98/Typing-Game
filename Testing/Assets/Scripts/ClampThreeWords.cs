using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ClampThreeWords : MonoBehaviour
{
    public TextMeshProUGUI nameLabel;
    public TextMeshProUGUI nameLabel2;
    public TextMeshProUGUI nameLabel3;
    //private int offset = 15;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position); // Bottom Text
        nameLabel.rectTransform.position = namePos;

      

        nameLabel3.rectTransform.position = namePos;
    }
}
