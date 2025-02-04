using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class GameManager : MonoBehaviour
{
    public GameObject enemy_1Prefab;
    public Transform player;
    public float spawnDistance;
    public float spawnDelay;
    public float individualSpawnDelay;

    void Start()
    {
        StartCoroutine(SpawnEnemiesLoop1());
    }

    //make 3 enemies spawn after delay
    IEnumerator SpawnEnemiesLoop1()
    {
        while (true)
        {
            for (int i = 0; i < 3; i++)
            {
                SpawnEnemy1();
                //wait half a second to spawn next
                yield return new WaitForSeconds(individualSpawnDelay);
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnEnemy1()
    {
        if (player == null) return;

        //set spawn point
        Vector3 spawnPosition = player.position + Vector3.right * spawnDistance;
        //spawn
        GameObject enemy = Instantiate(enemy_1Prefab, spawnPosition, Quaternion.identity);
        
        // Make the enemy face the player
        Vector3 direction = (player.position - enemy.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemy.transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
