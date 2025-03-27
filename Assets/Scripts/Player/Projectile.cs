using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifetime = 2.0f;
    [SerializeField] private float damage = 5f;
    [SerializeField] private LayerMask playerBoundary;

    private ParticlePool particlePool;
    void Start()
    {
        particlePool = GameObject.Find("ProjectileHits").GetComponent<ParticlePool>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
       // gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<HealthController>() != null)
        {
            other.gameObject.GetComponent<HealthController>().TakeDamage(damage);
        }

        if ((playerBoundary.value & (1 << other.gameObject.layer)) == 0) 
        {        
            gameObject.SetActive(false);
            particlePool.PlayParticle(transform.position);
            AudioManager.instance.PlayHitSound();
        }

        
    }

    private void OnEnable()
    {
        StartCoroutine(DeactivateSelf());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator DeactivateSelf()
    {
        yield return new WaitForSeconds(lifetime);
        gameObject.SetActive(false);
    }
}
