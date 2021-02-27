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

            RaycastHit hit;
            if (Physics.Linecast(transform.position, target.transform.position, out hit))
            {
                if (hit.transform.tag == "Obstacle")
                    return;
            }

            if (UtilityHelper.IsGOSleeping(gameObject))
                Shoot();
        }
        else
            target = null;
    }

    // Update is called once per frame
    void Update()
    {
        // target lock on
        if (target != null && UtilityHelper.IsGOSleeping(gameObject))
        {
            Vector3 dir = target.position - transform.position;
            UtilityHelper.ChangeRotation(transform, dir);
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
}
