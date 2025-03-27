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
            CameraShake.Instance.ShakeCamera(8f, 0.1f);
            gameObject.SetActive(false);
            PlayerHealth.instance.TakeDamage(10);
        }
    }
}
