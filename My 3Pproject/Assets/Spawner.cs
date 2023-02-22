using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    public GameObject enemyprefab;
    [SerializeField] public float enemiesToSpawn = 5;
    [SerializeField] public float activeEnemies = 0;
    [SerializeField] public float totalEnemiesSpawned = 0;
    [SerializeField] public float enemiesAtOnce = 2;
    public float deadEnemies = 0;
    public float originRandomOffset = 2;
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
        GameObject clone = Instantiate(enemyprefab, transform.position + RandomSpawnLocalPosition(), transform.rotation);
        //clone.transform.position = RandomSpawnPosition();
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

    Vector3 RandomSpawnLocalPosition()
    {

        float x = Random.Range(-originRandomOffset,originRandomOffset);
        float z = Random.Range(-originRandomOffset,originRandomOffset);
        return new Vector3(x, 0, z);
    }

    public void NotifyDeath(EnemyHealth enemyHealth)
    {
        activeEnemies--;
        deadEnemies++;
        if (totalEnemiesSpawned < enemiesToSpawn)
        {
            SpawnEnemy();
        }
        if (deadEnemies >= enemiesToSpawn)
        {
            onSpawnerEnd.Invoke();
        }
    }
}
    
