using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int numberOfEnemies;
    private int xPos;
    private int zPos;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SpawnEnemy()
    {
        while (numberOfEnemies > 0)
        {
            xPos = Random.Range(-10, 13);
            zPos = Random.Range(0, 12);

            GameObject instantiatedEnemy = Instantiate(enemy, new Vector3(xPos, 1f, zPos), Quaternion.identity);
            instantiatedEnemy.gameObject.tag = "Enemy";

            yield return new WaitForSeconds(0.001f);

            numberOfEnemies--;
        }
    }
}
