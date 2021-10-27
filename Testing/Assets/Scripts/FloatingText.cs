using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FloatingText : MonoBehaviour
{

    public Animator animator;
    private TextMeshProUGUI scoreText;

    private void Start()
    {
        AnimatorClipInfo[] clipInfo = animator.GetCurrentAnimatorClipInfo(0);
        Destroy(gameObject, clipInfo[0].clip.length-.2f);
        scoreText = animator.GetComponent<TextMeshProUGUI>();
    }

    public void setText(string text)
    {
        animator.GetComponent<TextMeshProUGUI>().text = text;
    }

}
