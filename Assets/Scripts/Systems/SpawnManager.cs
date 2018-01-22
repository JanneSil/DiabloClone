﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SpawnManager : MonoBehaviour {


    private bool hasSpawned;
    private Transform player;

    public GameObject[] EnemiesToSpawn;
    public int MaxSpawnAmount;

    //ranges
    public float SpawnRange;
    public float DetectionRange;

    private void Start()
    {
        player = PlayerManager.instance.Player.transform;
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        if (distance <= DetectionRange)
        {
            if (!hasSpawned)
            {
                SpawnEnemies();
            }


        }
    }

    void SpawnEnemies()
    {
        hasSpawned = true;

        int spawnAmount = Random.Range(1, MaxSpawnAmount+1);

        for (int i = 0; i < spawnAmount; i++)
        {
            //SQUARE
            //float xSpawnPos = transform.position.x + Random.Range(-SpawnRange, SpawnRange);
            //float zSpawnPos = transform.position.z + Random.Range(-SpawnRange, SpawnRange);

            //Vector3 spawnPoint = new Vector3(xSpawnPos, 0, zSpawnPos);

            //CIRCLE
            float theta = 360f * Random.value;
            float radius = Random.Range(0f, SpawnRange);

            Vector3 center = transform.position;
            Vector3 point = new Vector3(radius * Mathf.Sin(theta), 0, radius * Mathf.Cos(theta));

            Vector3 spawnPoint = center + point;

            //Look Rotation
            float rot = 360f * Random.value;
            Quaternion spawnRotation = Quaternion.Euler(0,rot,0);


            GameObject newEnemy = (GameObject)Instantiate(EnemiesToSpawn[Random.Range(0, EnemiesToSpawn.Length)], spawnPoint, spawnRotation);
        }

    }

    private void OnDrawGizmos()
    {
        Handles.color = Color.blue;
        Handles.DrawWireArc(transform.position, transform.up, transform.right, 360, DetectionRange);

        Handles.color = Color.red;
        Handles.DrawWireArc(transform.position, transform.up, transform.right, 360, SpawnRange);
    }

}
