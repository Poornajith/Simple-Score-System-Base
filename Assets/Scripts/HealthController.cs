using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private Image healthBarFillImage;

    private float currentHealth;
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0f) 
        {
            Die();
        }
        healthBarFillImage.fillAmount = currentHealth/maxHealth;
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }
}
