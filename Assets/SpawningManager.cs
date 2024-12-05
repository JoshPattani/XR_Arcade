using System.Collections;
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
        int spawnIndex = Random.Range(0, fishSpawnPoints.Length);
        Transform spawnPoint = fishSpawnPoints[spawnIndex];
        ObjectPooler.Instance.SpawnFromPool(fishTag, spawnPoint.position, spawnPoint.rotation);
    }

    void SpawnEnemyAtRandomPoint()
    {
        int spawnIndex = Random.Range(0, enemySpawnPoints.Length);
        Transform spawnPoint = enemySpawnPoints[spawnIndex];
        ObjectPooler.Instance.SpawnFromPool(enemyTag, spawnPoint.position, spawnPoint.rotation);
    }
}
