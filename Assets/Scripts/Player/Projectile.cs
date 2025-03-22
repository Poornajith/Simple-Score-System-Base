using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float lifetime = 2.0f;
    [SerializeField] private float damage = 5f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
        gameObject.SetActive(false);
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
