using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.Color;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private bool showWhenMaxHealth = true;
    [SerializeField] private HealthSystem healthSystem;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private Image healthImage;
    [SerializeField] private float lerpSpeed;

    void Awake()
    {
        healthSystem.onTakeDamage.AddListener(UpdateUi);

        if (showWhenMaxHealth.Equals(false))
        {
            healthImage.enabled = false;
            backgroundImage.enabled = false;
        }
    }

    private void UpdateUi()
    {
        healthImage.enabled = true;
        backgroundImage.enabled = true;
        
        float currentHealth = healthSystem.GetCurrentHealth();
        float startingHealth = healthSystem.GetStartingHealth();
        float smallHealth = (currentHealth / startingHealth);
        
        
        if (smallHealth < 0.5f && smallHealth > 0.25f) healthImage.color = new Color(251, 127, 0);
        if (smallHealth < 0.25f) healthImage.color = new Color(255, 0, 0);

        float fillAmount = Mathf.Lerp(healthImage.fillAmount, smallHealth, Time.deltaTime * lerpSpeed);
        healthImage.fillAmount = fillAmount;

        if (Math.Abs(healthImage.fillAmount - smallHealth) > 0.01) Invoke(nameof(UpdateUi), Time.deltaTime);
    }
}