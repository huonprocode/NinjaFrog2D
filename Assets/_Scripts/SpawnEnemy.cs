using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public float spawnRate = 2f;

    public List<Transform> listSpawnPoint;
    public List<GameObject> listEnemyPref;

    private void Start()
    {
        StartCoroutine(SpawnRandomPoint());
    }

    IEnumerator SpawnRandomPoint()
    {
        while (true)
        {
            int randomIndex = Random.Range(0, listSpawnPoint.Count);
            Transform selectedSpawn = listSpawnPoint[randomIndex];

            int randomEnemyIndex = Random.Range(0, listEnemyPref.Count);
            GameObject slectedEnemy = listEnemyPref[randomEnemyIndex];

            Instantiate(slectedEnemy, selectedSpawn.position, Quaternion.identity);

            yield return new WaitForSeconds(spawnRate);
        }
    }
}
