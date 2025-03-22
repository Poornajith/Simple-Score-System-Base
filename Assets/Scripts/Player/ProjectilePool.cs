using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int poolSize;

    private List<GameObject> projectiles;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectiles = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject projectile = Instantiate(projectilePrefab);
            projectile.SetActive(false);
            projectiles.Add(projectile);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void Shoot(Transform shootTransform)
    {
        foreach (GameObject projectile in projectiles)
        {
            if (!projectile.activeInHierarchy)
            {
                projectile.SetActive(true);
                projectile.transform.position = shootTransform.position;
                projectile.transform.rotation = shootTransform.rotation;
                break;
            }
        }
    }
}
