using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    private GameObject[] enemiesInVicinity;
    public Transform[] spawnLocations;

    private int count;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();
    }

    // Update is called once per frame
    void Update()
    {
        enemiesInVicinity = GameObject.FindGameObjectsWithTag("Enemy");
        
        if (enemiesInVicinity.Length == 0)
            SpawnEnemy();
    }

    private void SpawnEnemy() {
        count = spawnLocations.Length;

        while (count > 0)
        {
            GameObject instantiatedEnemy = Instantiate(enemyPrefab, spawnLocations[spawnLocations.Length - count].position, Quaternion.identity);
            instantiatedEnemy.gameObject.tag = "Enemy";

            count--;
        }
    }
}
