using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClampTwoNames : MonoBehaviour
{

    public TextMeshProUGUI nameLabel;
    public TextMeshProUGUI nameLabel2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        nameLabel.rectTransform.position = namePos;
        
        if(nameLabel != null)
        {
            namePos.y += 15;
        }

        nameLabel2.rectTransform.position = namePos;
    }
}

