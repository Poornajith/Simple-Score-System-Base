using NUnit.Framework;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance;

    [SerializeField] private GameObject spawnObjectPrefab;
    [SerializeField] private float spawnObjectYRange = 10f;
    [SerializeField] private float spawnObjectX = 10f;

    [SerializeField] private TextMeshProUGUI enemyCountTxt;
    [SerializeField] private TextMeshProUGUI waveNumTxt;

    public int poolSize = 10;

    private int waveNumber = 1;
    private int activeEnemyCount = 1;

    private List<GameObject> enemyPool;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        enemyPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++) 
        {
            GameObject spawnObject = Instantiate(spawnObjectPrefab);
            spawnObject.SetActive(false);
            enemyPool.Add(spawnObject);
        }
        StartWave(waveNumber);
    }

    // Update is called once per frame
    void Update()
    {
        activeEnemyCount = Object.FindObjectsByType<Enemy>(FindObjectsSortMode.None).Length;
        if(activeEnemyCount == 0)
        {
            waveNumber++;
            activeEnemyCount = waveNumber;
            StartWave(waveNumber);
        }
        waveNumTxt.text = "Wave: " + waveNumber;
        enemyCountTxt.text = "Remaining Enemies: " + activeEnemyCount;
    }

    public void IncreaseEnemyPoolSize(int size)
    {
        for (int i = 0; i < size; i++)
        {
            GameObject spawnObject = Instantiate(spawnObjectPrefab);
            spawnObject.SetActive(false);
            enemyPool.Add(spawnObject);
        }
        poolSize += size;
    }

    private void spawnEnemy()
    {
        foreach (GameObject spawnObject in enemyPool)
        {
            if (!spawnObject.activeInHierarchy)
            {
                spawnObject.GetComponent<HealthController>().SetMaxHealth();
                spawnObject.GetComponent<MoveForward>().RandomizeSpeed();
                spawnObject.SetActive(true);
                spawnObject.transform.position = spawnPosition();
                spawnObject.transform.rotation = Quaternion.Euler(0,-90,0);
                break;
            }
        }
    }

    private Vector3 spawnPosition() 
    { 
        Vector3 vector3 = 
            new Vector3(
                Random.Range(spawnObjectX, spawnObjectX + 10f),
                Random.Range(-spawnObjectYRange, spawnObjectYRange),
                0f);
        return vector3; 
    }

    private void StartWave(int enemyCount)
    {

        if (enemyPool.Count < waveNumber)
        {
            IncreaseEnemyPoolSize(1);
        }

        for (int i = 0; i < enemyCount; i++)
        {
            spawnEnemy();
        }
    }
}
