using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Spawner : Room_Basic
{
    [SerializeField]
    float MaxTimer = 10f;
    float SpawnTimer = 10f;
    [SerializeField]
    int Level = 1;
    [SerializeField]
    GameObject Minion;


    void Start()
    {
        SpawnTimer = MaxTimer;
        canBuild = false;
    }

    // Update is called once per frame
    void Update()
    {
        SpawnTimer -= Time.deltaTime;
        if (SpawnTimer <= 0f)
        {
            TriggerSpawn();
            SpawnTimer = MaxTimer;
        }
    }

    void TriggerSpawn()
    {
        manager.SpawnMinion(Minion, Level);
    }
}
