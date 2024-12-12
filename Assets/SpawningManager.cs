using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningManager : MonoBehaviour
{
    [Header("Spawning Settings")]
    public string fishTag = "Fish";
    public string enemyTag = "Enemy";
    public Transform[] fishSpawnPoints;
    public Transform[] enemySpawnPoints;
    public float fishSpawnInterval = 2f;
    public float enemySpawnInterval = 5f;
    public int maxFish = 10;
    public int maxEnemies = 3;

    [SerializeField]
    [Tooltip("The list of prefabs available to spawn.")]
    List<GameObject> m_ObjectPrefabs = new List<GameObject>();

    /// <summary>
    /// The list of prefabs available to spawn.
    /// </summary>
    public List<GameObject> objectPrefabs
    {
        get => m_ObjectPrefabs;
        set => m_ObjectPrefabs = value;
    }

    void Start()
    {
        StartCoroutine(SpawnFish());
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnFish()
    {
        while (true)
        {
            SpawnFishAtRandomPoint();
            yield return new WaitForSeconds(fishSpawnInterval);
        }
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            SpawnEnemyAtRandomPoint();
            yield return new WaitForSeconds(enemySpawnInterval);
        }
    }

    void SpawnFishAtRandomPoint()
    {
        if (fishSpawnPoints.Length == 0 || fishSpawnPoints.Length > maxFish)
        {
            return;
        }
        int randomIndex = Random.Range(0, fishSpawnPoints.Length);
        Transform spawnPoint = fishSpawnPoints[randomIndex];
        GameObject fishPrefab = objectPrefabs.Find(prefab => prefab.CompareTag(fishTag));
        if (fishPrefab != null)
        {
            Instantiate(fishPrefab, spawnPoint.position, spawnPoint.rotation);
        }

    }

    void SpawnEnemyAtRandomPoint()
    {
        if (enemySpawnPoints.Length == 0 || enemySpawnPoints.Length > maxEnemies)
        {
            return;
        }
        int randomIndex = Random.Range(0, enemySpawnPoints.Length);
        Transform spawnPoint = enemySpawnPoints[randomIndex];
        GameObject enemyPrefab = objectPrefabs.Find(prefab => prefab.CompareTag(enemyTag));
        if (enemyPrefab != null)
        {
            Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
        }
    }
}
