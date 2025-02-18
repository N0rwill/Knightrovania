using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager_2 : MonoBehaviour
{
    public GameObject enemy_2Prefab;
    [SerializeField] private Transform player;
    public float spawnDistance;
    public float spawnDistanceUp;
    public float spawnDelay;
    public float individualSpawnDelay;
    Vector3 spawnPosition;

    void Start()
    {
        StartCoroutine(SpawnEnemiesLoop1());
    }

    void FixedUpdate()
    {
        //set spawn point
        spawnPosition = player.position + Vector3.right * spawnDistance;
    }

    //make 3 enemies spawn after delay
    IEnumerator SpawnEnemiesLoop1()
    {
        while (true)
        {
            for (int i = 0; i < 2; i++)
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
        Debug.Log("spawn position set");

        //spawn
        GameObject enemy = Instantiate(enemy_2Prefab, spawnPosition, Quaternion.identity);

        // Make the enemy face the player
        Vector3 direction = (player.position - enemy.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemy.transform.rotation = Quaternion.Euler(0, angle, 0);
    }
}
