using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private int poolSize;
    [SerializeField] private float projectileDelay = 0.3f;

    private List<GameObject> projectiles;
    private float timeSinceLastProjectileFire;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        projectiles = new List<GameObject>();
        timeSinceLastProjectileFire = Mathf.Infinity;
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
        timeSinceLastProjectileFire += Time.deltaTime;
    }

    public void Shoot(Transform shootTransform)
    {
        if (timeSinceLastProjectileFire >= projectileDelay)
        {
            timeSinceLastProjectileFire = 0;
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
}
