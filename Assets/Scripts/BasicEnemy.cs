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
        SetPositionOfHB(hBInstance, transform);
        hBInstance.value = ReturnHP();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);

        hBInstance.value = ReturnHP();
        
        if (ReturnHP() <= 0)
            Destroy(gameObject);

        if (hBInstance != null)
            SetPositionOfHB(hBInstance, transform);
    }

    float ReturnHP()
    {
        return currentHealth / maxHealth;
    }

    void SetPositionOfHB(Slider healthBar, Transform location)
    {
        Vector2 screenPosition = Camera.main.WorldToScreenPoint(location.position);
        screenPosition += new Vector2(0f, 40f);
        healthBar.transform.position = screenPosition;
    }
}
