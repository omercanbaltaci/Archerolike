using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekEnemyAndShoot : MonoBehaviour
{
    public Transform target;
    public string targetTag;
    public float turnSpeed;
    
    public float fireRate = 1f;
    private float fireCountdown = 0f;

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
                shortestDistance = distance;
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
        /*
        Vector3 direction = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if (playerRB.IsSleeping())
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        */

        if (fireCountdown == 0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        Debug.Log("Shoot");
    }
}
