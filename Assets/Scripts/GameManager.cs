using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnDistance = 50f;
    public float spawnDelay = 5f;
    public float individualSpawnDelay = 1f;

    void Start()
    {
        StartCoroutine(SpawnEnemiesLoop());
    }

    IEnumerator SpawnEnemiesLoop()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                SpawnEnemy();
                yield return new WaitForSeconds(individualSpawnDelay);
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        Vector3 spawnPosition = player.position + Vector3.right * spawnDistance;
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        
        // Make the enemy face the player
        Vector3 direction = (player.position - enemy.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemy.transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
