using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float deactivateX = -10f;

    private ParticlePool particlePool;

    private void Start()
    {
        particlePool = GameObject.Find("EnemyExplosions").GetComponent<ParticlePool>();
    }
    private void Update()
    {
        if (transform.position.x < deactivateX)
        {
            particlePool.PlayParticle(transform.position);
            AudioManager.instance.PlayExplosionSound();
            gameObject.SetActive(false);
            PlayerHealth.instance.TakeDamage(10);
        }
    }
}
