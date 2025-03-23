using System.Collections;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject powerUpGuns;
    [SerializeField] private float powerUpDuration = 5f;
    [SerializeField] private float xRange = 10f;
    [SerializeField] private float yRange = 8f;

    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        boxCollider = GetComponent<BoxCollider>();
        powerUpGuns.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Player"))
        {
            meshRenderer.enabled = false;
            boxCollider.enabled = false;
            RandomizePosition();
            powerUpGuns.SetActive(true);
            StartCoroutine(PowerUpCountdown());
        }
    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        powerUpGuns.SetActive(false);
        meshRenderer.enabled = true;
        boxCollider.enabled = true;
    }

    private void RandomizePosition()
    {
        transform.position = new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange), 0);
    }
}
