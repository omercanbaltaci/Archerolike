using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    private float oldID;

    [Header("Targeting")]
    public Transform target;
    public GameObject indicatorPrefab;
    public string targetTag;
    public float turnSpeed;
    
    [Header("Attributes")]
    public float fireRate = 3f;
    private float fireCountdown = 0f;

    [Header("Bullet")]
    public GameObject bulletPrefab;
    public Transform firePoint;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating(nameof(UpdateTarget), 0f, 0.5f);

        oldID = target.GetInstanceID();
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
                // checks if there is an obstacle between player and target
                if (Physics.Linecast(transform.position, enemy.transform.position, out RaycastHit hit))
                {
                    if (hit.transform.CompareTag("Obstacle"))
                        continue;
                }

                shortestDistance = distance;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null)
        {
            target = nearestEnemy.transform;

            if (oldID != target.GetInstanceID())
            {

                GameObject[] indicators = GameObject.FindGameObjectsWithTag("Indicator");

                if (indicators.Length > 0) 
                { 
                    Destroy(indicators[0]);

                    InstantiateIndicator(indicatorPrefab, target);
                }
                else
                {
                    InstantiateIndicator(indicatorPrefab, target);
                }

                oldID = target.GetInstanceID();
            }
        }
            
        else
            target = null;
    }

    // Update is called once per frame
    void Update()
    {
        // Locking on target
        if (target != null && UtilityHelper.IsGameObjectSleeping(gameObject))
        {
            Vector3 dir = target.position - transform.position;
            UtilityHelper.ChangeRotation(transform, dir);
        }

        if (fireCountdown <= 0f)
        {
            if (UtilityHelper.IsGameObjectSleeping(gameObject))
                Shoot();
            
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;
    }

    void Shoot()
    {
        GameObject bulletGO = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
            bullet.Seek(target);
    }

    void InstantiateIndicator(GameObject indicatorPrefab, Transform target)
    {
        GameObject indicatorInstance = Instantiate(indicatorPrefab);
        indicatorInstance.transform.SetParent(target, false);
        indicatorInstance.transform.position = target.position;
    }
}
