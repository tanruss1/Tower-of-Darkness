using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Spawner : Room_Basic
{
    public enum SpawnerType { Zombie, Skeleton, Goblin};
    [SerializeField]
    float MaxTimer = 10f;
    float SpawnTimer = 10f;
    [SerializeField]
    int Level = 1;
    [SerializeField]
    SpawnerType Minion;

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
            SpawnTimer = MaxTimer;
        }
    }

    void TriggerSpawn()
    {
        GameObject minion = new GameObject();
        if (Minion == SpawnerType.Zombie)
        {
            //minion = new Zombie;
        }
        else if (Minion == SpawnerType.Skeleton)
        {
            //minion = new Skeleton
        }
        else if (Minion == SpawnerType.Goblin)
        {
            //minion = new Goblin
        }
        manager.SpawnMinion(minion, Level);
    }
}
