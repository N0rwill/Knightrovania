using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform player;
    public float spawnDistance;
    public float spawnDelay;
    public float individualSpawnDelay;

    void Start()
    {
        StartCoroutine(SpawnEnemiesLoop());
    }

    //make 3 enemies spawn after delay
    IEnumerator SpawnEnemiesLoop()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                SpawnEnemy();
                //wait half a second to spawn next
                yield return new WaitForSeconds(individualSpawnDelay);
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnEnemy()
    {
        if (player == null) return;

        //set spawn point
        Vector3 spawnPosition = player.position + Vector3.right * spawnDistance;
        //spawn
        GameObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
        
        // Make the enemy face the player
        Vector3 direction = (player.position - enemy.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemy.transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
