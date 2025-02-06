using System.Collections;
using System.Collections.Generic;
using UnityEngine.U2D.Animation;
using UnityEngine;

public class GameManager_3 : MonoBehaviour
{
    public GameObject enemy_3Prefab;
    [SerializeField] private Transform player;
    public Camera mainCamera;
    public float spawnDistance;
    public float spawnDistance2;
    public float spawnDistanceUp;
    public float spawnDelay;
    Vector3 spawnPosition;

    void Start()
    {
        StartCoroutine(SpawnEnemiesLoop1());
    }

    //make enemies spawn after delay
    IEnumerator SpawnEnemiesLoop1()
    {
        while (true)
        {
            for (int i = 0; i < 1; i++)
            {
                SpawnEnemyLeft();
                SpawnEnemyRight();
            }
            yield return new WaitForSeconds(spawnDelay);
        }
    }

    void SpawnEnemyLeft()
    {
        if (player == null) return;

        //set spawn point
        Vector3 spawnPosition = new Vector3(player.position.x + spawnDistance2, mainCamera.transform.position.y + spawnDistanceUp, player.position.z);

        //spawn
        GameObject enemy = Instantiate(enemy_3Prefab, spawnPosition, Quaternion.identity);

        // Make the enemy face the player
        Vector3 direction = (player.position - enemy.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemy.transform.rotation = Quaternion.Euler(0, angle, 0);

        Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
        enemyRb.AddForce(Vector3.up * 1500f);
    }

    void SpawnEnemyRight()
    {
        if (player == null) return;

        //set spawn point
        Vector3 spawnPosition = new Vector3(player.position.x + spawnDistance, mainCamera.transform.position.y + spawnDistanceUp, player.position.z);

        //spawn
        GameObject enemy = Instantiate(enemy_3Prefab, spawnPosition, Quaternion.identity);

        // Make the enemy face the player
        Vector3 direction = (player.position - enemy.transform.position).normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        enemy.transform.rotation = Quaternion.Euler(0, angle, 0);

        Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
        enemyRb.AddForce(Vector3.up * 1500f);
    }
}
