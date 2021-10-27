using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleSystemTrigger : MonoBehaviour
{
    public ParticleSystem a;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Projectile" && tag == "Marked for death")
        {
            GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllOneCharWrong();
            GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllTwoCharWrong();
            GameObject.FindGameObjectWithTag("ResetChar").GetComponent<ResetCharWrongAll>().wipeAllThreeCharWrong();
            FloatingTextController.CreateFloatingText("+" + GameObject.FindGameObjectWithTag("Score Tracker").GetComponent<ScoreTracker>().popUpTextPoints.ToString(), transform);
            Instantiate(a, transform.position, Quaternion.identity);
        }
    }
}
