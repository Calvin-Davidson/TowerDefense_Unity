using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private HealthSystem _healthSystem;
        [SerializeField] private Image _healthImage;
        [SerializeField] private float _LerpSpeed;
        
        void Awake()
        {
            _healthSystem.OnTakeDamage.AddListener(UpdateUi);   
        }
        private void UpdateUi()
        {
            float currentHealth = _healthSystem.getCurrentHealth();
            float startingHealth = _healthSystem.getStartingHealth();
            
            if (currentHealth / startingHealth < 0.5f) _healthImage.color = new Color(251, 127, 0);
            if (currentHealth / startingHealth < 0.25f) _healthImage.color = Color.red;
            
            float fillAmount = Mathf.Lerp(_healthImage.fillAmount, (currentHealth / startingHealth), Time.deltaTime * _LerpSpeed);
            _healthImage.fillAmount = fillAmount;
            
            StartCoroutine(UpdateHealthTimer());
        }
        private IEnumerator UpdateHealthTimer()
        {
            yield return new WaitForFixedUpdate();
            if (Math.Abs(_healthImage.fillAmount - (_healthSystem.getCurrentHealth() / _healthSystem.getStartingHealth())) > 0.01) UpdateUi();
        }
    }
}