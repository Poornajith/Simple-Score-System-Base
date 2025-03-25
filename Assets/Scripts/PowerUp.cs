using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private GameObject powerUpGuns;
    [SerializeField] private GameObject singleModeImg;
    [SerializeField] private GameObject BoostModeImg;

    [SerializeField] private MeshRenderer powerUpMesh;

    [SerializeField] private float powerUpDuration = 5f;
    [SerializeField] private float xRange = 10f;
    [SerializeField] private float yRange = 8f;

    private MeshRenderer meshRenderer;
    private BoxCollider boxCollider;

    private void Start()
    {        
        boxCollider = GetComponent<BoxCollider>();
        powerUpGuns.SetActive(false);
        BoostModeImg.SetActive(false);
    }
    private void OnTriggerEnter(Collider other)
    {
         if (other.CompareTag("Player"))
        {
            powerUpMesh.enabled = false;
            boxCollider.enabled = false;
            RandomizePosition();
            powerUpGuns.SetActive(true);
            BoostModeImg.SetActive(true);
            singleModeImg.SetActive(false);
            StartCoroutine(PowerUpCountdown());
        }
    }

    IEnumerator PowerUpCountdown()
    {
        yield return new WaitForSeconds(powerUpDuration);
        powerUpGuns.SetActive(false);

        BoostModeImg.SetActive(false);
        singleModeImg.SetActive(true);

        powerUpMesh.enabled = true;
        boxCollider.enabled = true;
    }

    private void RandomizePosition()
    {
        transform.position = new Vector3(Random.Range(-xRange, xRange), Random.Range(-yRange, yRange), 0);
    }
}
