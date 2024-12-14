using System;
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
    
    [Header("Fish Settings")]
    public float fishSpeed = 1.0f;
    public float fishPathLength = 10.0f;

    [Header("Enemy Settings")]
    public float enemySpeed = 1.0f;
    public float enemyPathLength = 10.0f;

    [SerializeField]
    [Tooltip("The list of prefabs available to spawn.")]
    List<GameObject> m_ObjectPrefabs = new();

    /// <summary>
    /// The list of prefabs available to spawn.
    /// </summary>
    public List<GameObject> ObjectPrefabs
    {
        get => m_ObjectPrefabs;
        set => m_ObjectPrefabs = value;
    }

    /// <summary>
    // List of waypoints assigned to fish prefabs in FollowThePath script component.
    /// </summary>
    /// 
    public Transform[] fishWaypoints;
    public Transform[] enemyWaypoints;


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
        int randomIndex = UnityEngine.Random.Range(0, fishSpawnPoints.Length);
        Transform spawnPoint = fishSpawnPoints[randomIndex];
        GameObject fishPrefab = ObjectPrefabs.Find(prefab => prefab.CompareTag(fishTag));
        if (fishPrefab != null)
        {
            // Instantiate fish prefab at spawn point as a child of the spawn manager
            GameObject fish = Instantiate(fishPrefab, spawnPoint.position, Quaternion.identity);
            fish.transform.parent = transform;
            // Set fish's initial speed and direction
            FollowThePath followThePath = fish.GetComponent<FollowThePath>();
            followThePath.moveSpeed = fishSpeed;
            followThePath.pathLength = fishPathLength;

            // Randomize the waypoints for the fish to swim to and assign them to the fish's followThePath component
            followThePath.waypoints = fishWaypoints;
        }

    }

    void SpawnEnemyAtRandomPoint()
    {
        if (enemySpawnPoints.Length == 0 || enemySpawnPoints.Length > maxEnemies)
        {
            return;
        }
        int randomIndex = UnityEngine.Random.Range(0, enemySpawnPoints.Length);
        Transform spawnPoint = enemySpawnPoints[randomIndex];
        GameObject enemyPrefab = ObjectPrefabs.Find(prefab => prefab.CompareTag(enemyTag));
        if (enemyPrefab != null)
        {
            // Instantiate enemy prefab at spawn point as a child of the spawn manager
            GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
            enemy.transform.parent = transform;
            // Set enemy's initial speed and direction
            FollowThePath followThePath = enemy.GetComponent<FollowThePath>();
            followThePath.moveSpeed = enemySpeed;
            followThePath.pathLength = enemyPathLength;

            // Randomize the waypoints for the enemy to walk to and assign them to the enemy's followThePath component
            followThePath.waypoints = enemyWaypoints;
        }
    }
}
