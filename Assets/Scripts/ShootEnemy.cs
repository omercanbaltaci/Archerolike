using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    [Header("Targeting")]
    public Transform target;
    public string targetTag;
    public float turnSpeed;
    
    [Header("Attributes")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Bullet")]
    public GameObject bulletPrefab;
    public Transform firePoint;

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
        {
            target = nearestEnemy.transform;

            if (IsGOSleeping())
                Shoot();
        }
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
        if (target != null)
        {
            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            Vector3 rotation = Quaternion.Lerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
            
            if (IsGOSleeping())
                transform.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }

        if (fireCountdown == 0f)
            fireCountdown = 1f / fireRate;

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    private bool IsGOSleeping()
    {
        if (gameObject.GetComponent<Rigidbody>().velocity == new Vector3(0f, 0f, 0f))
            return true;
        else return false;
    }
}
