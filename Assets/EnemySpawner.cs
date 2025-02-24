using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject spawnArea;
    public float spawnInterval = 2f;

    private float minX, maxX, minZ, maxZ;

    void Start()
    {
        Collider areaCollider = spawnArea.GetComponent<Collider>();
        if (areaCollider != null)
        {
            minX = areaCollider.bounds.min.x;
            maxX = areaCollider.bounds.max.x;
            minZ = areaCollider.bounds.min.z;
            maxZ = areaCollider.bounds.max.z;
        }
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnInterval);
            Vector3 randomSpawnPos = new Vector3(
                    Random.Range(minX, maxX),
                    spawnArea.transform.position.y, // Adjust height based on plane
                    Random.Range(minZ, maxZ)
                );
            Instantiate(enemyPrefab, randomSpawnPos, Quaternion.identity);
        }
    }
}
