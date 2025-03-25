using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab; // Assign Enemy prefab in Inspector
    public float spawnRate = 2f;   // Time between spawns in seconds
    public Camera mainCamera;      // Assign Main Camera (or use Camera.main)

    private float nextSpawnTime;

    void Start()
    {
        if (mainCamera == null)
            mainCamera = Camera.main;
        nextSpawnTime = 0f;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnEnemy();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnEnemy()
    {
        // Spawn at top of screen (maxZ) with random X
        float distance = Mathf.Abs(mainCamera.transform.position.y - transform.position.y);
        Vector3 leftTop = mainCamera.ScreenToWorldPoint(new Vector3(0, Screen.height, distance));
        Vector3 rightTop = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, distance));
        float spawnX = Random.Range(leftTop.x, rightTop.x);
        float spawnZ = rightTop.z; // Top edge

        Vector3 spawnPosition = new Vector3(spawnX, 0f, spawnZ);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
    }
}