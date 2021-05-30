using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class BasicEnemy : MonoBehaviour
{
    private Slider hBInstance;
    private Transform player;

    [Header("Attributes")]
    public NavMeshAgent enemy;
    public float enemySpeed;
    public float maxHealth;
    public float currentHealth;
    public Slider healthBar;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        enemy.speed = enemySpeed;
        currentHealth = maxHealth;

        hBInstance = Instantiate(healthBar);
        hBInstance.transform.SetParent(GameObject.Find("Canvas").transform, false);
        SetPositionOfHealthBar(hBInstance, transform);
        hBInstance.value = ReturnHitPoint();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);

        hBInstance.value = ReturnHitPoint();
        
        if (ReturnHitPoint() <= 0)
            Destroy(gameObject);

        if (hBInstance != null)
            SetPositionOfHealthBar(hBInstance, transform);

        // always look at the player
        Vector3 dir = player.position - transform.position;
        UtilityHelper.ChangeRotation(transform, dir);
    }

    float ReturnHitPoint()
    {
        return currentHealth / maxHealth;
    }

    void SetPositionOfHealthBar(Slider healthBar, Transform location)
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);
        screenPosition += new Vector2(0f, 15f);
        healthBar.transform.position = screenPosition;
    }
}
