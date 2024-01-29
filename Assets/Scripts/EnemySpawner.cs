using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject[] enemyPrefabs;
    public int numberOfEnemies = 5;
    public float spawnDistanceMin = 5f;
    public float spawnDistanceMax = 15f;
    public float spawnInterval = 3f;

    void Start()
    {
        // Assuming your player has a GameObject reference or you can find it using tags, etc.
        GameObject player = GameObject.FindWithTag("Player");

        if (player != null && enemyPrefabs.Length > 0)
        {
            // Spawn enemies randomly around the player initially
            SpawnRandomEnemies();

            // Schedule the method to be called every spawnInterval seconds
            InvokeRepeating("SpawnEnemy", 0f, spawnInterval);
        }
        else
        {
            Debug.LogError("Player not found or no enemy prefabs assigned. Make sure the player has the appropriate tag and enemy prefabs are assigned.");
        }
    }

    void SpawnRandomEnemies()
    {
        for (int i = 0; i < numberOfEnemies; i++)
    {
        SpawnSingleEnemy();
    }
    }
    void SpawnEnemy()
    {
        SpawnSingleEnemy();
    }

    void SpawnSingleEnemy()
    {
        // Randomly select an enemy prefab
        GameObject selectedEnemyPrefab = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        // Calculate a random spawn distance and angle
        float randomSpawnDistance = Random.Range(spawnDistanceMin, spawnDistanceMax);
        float randomAngle = Random.Range(0f, 360f);
        Vector3 spawnDirection = Quaternion.Euler(0, randomAngle, 0) * transform.forward;
        Vector3 spawnPosition = transform.position + spawnDirection * randomSpawnDistance;

        // Instantiate the selected enemy prefab at the calculated spawn position
        Instantiate(selectedEnemyPrefab, spawnPosition, Quaternion.identity);
    }
}