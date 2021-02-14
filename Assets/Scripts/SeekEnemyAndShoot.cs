using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekEnemyAndShoot : MonoBehaviour
{
    private Transform target;
    public string targetTag;
    public float turnSpeed;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(targetTag);

        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        // seeks for the nearest enemy
        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (distance < shortestDistance)
            {
                distance = shortestDistance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
            target = nearestEnemy.transform;
        else
            target = null;
    }

    // Update is called once per frame
    void Update()
    {
        /* modify this later to change scene maybe
        if (target == null)
            return;
        */

        // target lock on
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (gameObject.GetComponent<Rigidbody>().IsSleeping())
        {
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
    }
}
