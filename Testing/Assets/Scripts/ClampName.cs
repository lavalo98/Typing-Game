using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ClampName : MonoBehaviour
{

    public TextMeshProUGUI nameLabel;
    public Image healthBar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        healthBar.rectTransform.position = namePos;
        namePos.y = namePos.y + 10f;
        nameLabel.rectTransform.position = namePos;
    }
}
