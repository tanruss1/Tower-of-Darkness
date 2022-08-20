using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Graveyard : Room_Basic
{
    [SerializeField]
    float SpawnTimer = 10f;
    [SerializeField]
    int Level = 1;
    [SerializeField]
    GameObject Zombie;

    // Update is called once per frame
    void Update()
    {
        SpawnTimer -= Time.deltaTime;
        if (SpawnTimer <= 0f)
        {
            SpawnTimer = 10f;
        }
    }

    void TriggerSpawn()
    {
        manager.SpawnMinion(Zombie, Level);
    }
}
