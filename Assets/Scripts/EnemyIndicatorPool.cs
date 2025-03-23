using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIndicatorPool : MonoBehaviour
{
    public static EnemyIndicatorPool Instance;

    [SerializeField] private GameObject enemyIndicatorPrefab;
    [SerializeField] private int poolSize = 10;

    private List<GameObject> enemyIndicatorPool;
    public List<GameObject> activeEnemies;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        enemyIndicatorPool = new List<GameObject>();
        activeEnemies = new List<GameObject>();
        for(int i = 0; i < poolSize; i++)
        {
            GameObject enemyIndicator = Instantiate(enemyIndicatorPrefab);
            enemyIndicator.SetActive(false);
            enemyIndicatorPool.Add(enemyIndicator);
        }
    }
    
    public GameObject GetEnemyIndicator()
    {
        foreach (GameObject enemyIndicator in enemyIndicatorPool)
        {
            if (!enemyIndicator.activeInHierarchy)
            {
                enemyIndicator.SetActive(true);
                return enemyIndicator;
            }
        }
        GameObject newEnemyIndicator = Instantiate(enemyIndicatorPrefab);
        enemyIndicatorPool.Add(newEnemyIndicator);
        return newEnemyIndicator;
    }
}
