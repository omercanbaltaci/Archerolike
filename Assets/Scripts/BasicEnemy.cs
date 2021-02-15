﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    public NavMeshAgent enemy;
    //public GameObject hBPrefab;
    
    private Transform player;
    private GameObject healthBar;
    private Quaternion staticRotation;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        /*
        healthBar = Instantiate(hBPrefab, transform);
        staticRotation = healthBar.transform.rotation;
        */
    }

    // Update is called once per frame
    void Update()
    {
        enemy.SetDestination(player.position);
        
        /*
        healthBar.transform.position = new Vector3(transform.position.x, 5f, transform.position.z + 2f);
        healthBar.transform.rotation = staticRotation;
        */
    }
}