using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnLocations;

    [Header("Number of Enemies")]
    public int count;

    // Start is called before the first frame update
    void Start()
    {
        while (count > 0)
        {
            GameObject instantiatedEnemy = Instantiate(enemyPrefab, spawnLocations[spawnLocations.Length - count].position, Quaternion.identity);
            instantiatedEnemy.gameObject.tag = "Enemy";

            count--;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
