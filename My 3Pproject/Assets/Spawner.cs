using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject enemyprefab;
    public float enemiesToSpawn = 5;
    public float activeEnemies = 0;
    public float totalEnemiesSpawned;
    public float enemiesAtOnce = 2;
    public UnityEvent onSpawnerEnd; 
    // Start is called before the first frame update
    void Start()
    {
        activeEnemies = 0;
        totalEnemiesSpawned = 0;
        if (enemiesToSpawn > 0) SpawnEnemy();
    }
    void SpawnEnemy()
    {
        activeEnemies++;
        totalEnemiesSpawned++;
        GameObject clone = Instantiate(enemyprefab);

        clone.transform.position = RandomSpawnPosition();
        EnemyHealth enemyhHealth = clone.GetComponent<EnemyHealth>();
        if (enemyhHealth != null)
        {
            enemyhHealth.RegisterSpawner(this);
        }
        if (activeEnemies <= enemiesAtOnce)
        {
            SpawnEnemy();
        }
    }
    public void NotifyDeath(EnemyHealth enemyHealth)
    {
        activeEnemies--;
        if (totalEnemiesSpawned <= enemiesToSpawn)
        {
            SpawnEnemy();
        }
        else
        {
            onSpawnerEnd.Invoke();
        }
    }
    Vector3 RandomSpawnPosition()
    {
        float x = Random.Range(transform.position.x - 2f, transform.position.x + 2f);
        float z = Random.Range(transform.position.z - 2f, transform.position.z + 2f);
        return new Vector3(x, transform.position.y, z);
    }
}
