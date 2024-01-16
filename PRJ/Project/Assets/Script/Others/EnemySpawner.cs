using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private GameObject bossPrefab;
    [SerializeField] private float spawnCD = 5f;
    private bool isBossSpawned = false;
    [SerializeField] private int enemiesLimit = 3;
    private int spawnedEnemies = 0;
    public bool canSpawn;
    private Coroutine spawnCoroutine;
    void Start()
    {
        spawnedEnemies = 0;
        canSpawn = true;
    }

    public void startSpawning()
    {
            spawnCoroutine = StartCoroutine(SpawnEnemy());
    }
    private IEnumerator SpawnEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnCD);

        UnityEngine.Debug.Log("Start Spawning");
        while (canSpawn)
        {
            yield return wait;
            //spawn enemy randomly from 10 to 30  radius around player
            if (spawnedEnemies < enemiesLimit)
            {
                Vector2 randomPosition = Random.insideUnitCircle * Random.Range(20f, 30f);
                randomPosition += (Vector2)transform.position;
                Instantiate(enemyPrefab, randomPosition, Quaternion.identity);
                spawnedEnemies++;
            }
            else if (!isBossSpawned)
            {
                Vector2 randomPosition = Random.insideUnitCircle * Random.Range(50f, 80f);
                randomPosition += (Vector2)transform.position;
                Instantiate(bossPrefab, randomPosition, Quaternion.identity);
                isBossSpawned = true;
            }
        }
    }
}
