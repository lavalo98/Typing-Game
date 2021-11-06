using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ClampMainMenu : MonoBehaviour
{
    public TextMeshProUGUI nameLabel;

    // Start is called before the first frame update
    void Start() {

    }

    private void Awake() {
        nameLabel.enabled = false;
    }

    // Update is called once per frame
    void Update() {
        Vector3 namePos = Camera.main.WorldToScreenPoint(this.transform.position);
        namePos.y = namePos.y + 10f;
        nameLabel.rectTransform.position = namePos;

        nameLabel.enabled = true;
    }
}
