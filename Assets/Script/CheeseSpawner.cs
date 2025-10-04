using UnityEngine;

public class CheeseSpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs; // Array of enemy prefabs to spawn
    public Transform[] spawnPoints;   // Array of potential spawn locations

    public float timeBetweenSpawns = 2f;
    private float nextSpawnTime;

    void Start()
    {
        nextSpawnTime = Time.time + timeBetweenSpawns;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + timeBetweenSpawns;
        }
    }

    void SpawnEnemy()
    {
        // Choose a random enemy prefab from the array
        int randomEnemyIndex = Random.Range(0, enemyPrefabs.Length);
        GameObject enemyToSpawn = enemyPrefabs[randomEnemyIndex];

        // Choose a random spawn point from the array
        int randomSpawnPointIndex = Random.Range(0, spawnPoints.Length);
        Transform chosenSpawnPoint = spawnPoints[randomSpawnPointIndex];

        // Instantiate the chosen enemy at the chosen spawn point
        Instantiate(enemyToSpawn, chosenSpawnPoint.position, chosenSpawnPoint.rotation);
    }
    
}
