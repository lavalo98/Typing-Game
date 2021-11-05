using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar3Word : MonoBehaviour
{
    private Image healthBar;
    public float currentHealth;
    public float previousHealth;
    public float displayHealth;
    [SerializeField] private float lerpSpeed;
    threeWordTyper threeWordEnemy;

    private void Start() {
        healthBar = GetComponent<Image>();
        threeWordEnemy = FindObjectOfType<threeWordTyper>();
        currentHealth = threeWordEnemy.health;
        previousHealth = currentHealth;
        healthBar.color = Color.green;
    }

    private void handleBar() {
        if ((currentHealth / 100) != healthBar.fillAmount) {
            healthBar.fillAmount = Mathf.Lerp(healthBar.fillAmount, currentHealth / 100, Time.deltaTime * lerpSpeed);
        }
    }

    private void Update() {
        currentHealth = threeWordEnemy.health;
        handleBar();
        if (healthBar.fillAmount < 1 && healthBar.fillAmount >= .67) {
            healthBar.color = Color.green;
        }
        else if (healthBar.fillAmount < .67 && healthBar.fillAmount >= .33) {
            healthBar.color = Color.yellow;
        }
        else if (healthBar.fillAmount < .33 && healthBar.fillAmount >= 0) {
            healthBar.color = Color.red;
        }
    }
}
