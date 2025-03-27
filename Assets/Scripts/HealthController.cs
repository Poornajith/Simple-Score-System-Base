using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float maxHealth = 100;
    [SerializeField] private int points = 5;
    [SerializeField] private Image healthBarFillImage;

    private float currentHealth;
    private ParticlePool particlePool;
    void Start()
    {
        currentHealth = maxHealth;
        particlePool = GameObject.Find("EnemyExplosions").GetComponent<ParticlePool>();    
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
        ScoreManager.instance.UpdateScore(points);
        CameraShake.Instance.ShakeCamera(5f, 0.1f);
        particlePool.PlayParticle(transform.position);
        AudioManager.instance.PlayExplosionSound();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
    }

    public void SetMaxHealth()
    {
        currentHealth = maxHealth;
    }
}
