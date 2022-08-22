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
    [SerializeField]
    public enum MinionType {Goblin, Skeleton, Zombie};

    [SerializeField]
    MinionType type;

    void Start()
    {
        GameObject[] objects = FindObjectsOfType<GameObject>();
        foreach (GameObject _object in objects)
        {
            if (_object.GetComponent<GameManager>())
                manager = _object.GetComponent<GameManager>();
        }

        
        if (type == MinionType.Zombie)
        {
            MainText = "Upgrade zombie spawner";
            MaxTimer = 20f;
            Upgrade1 = IncreaseSpawnChance;
            Upgrade1_Text = "Increase Spawn Chance";
        }
        else
        {
            if (type == MinionType.Skeleton)
            {
                MainText = "Upgrade skeleton spawner";
                MaxTimer = 15f;
            }
            else
            {
                MainText = "Upgrade goblin spawner";
                MaxTimer = 10f;
            }
            Upgrade1 = IncreaseSpawnRate;
            Upgrade1_Text = "Increase Spawn Rate";
        }

        SpawnTimer = MaxTimer;
        canBuild = false;

        Upgrade2 = IncreaseLevel;
        Upgrade2_Text = "Increase Level";
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
        Debug.Log("Triggering " + Minion.name + " spawn");
        manager.SpawnMinion(Minion, Level);
    }

    public void IncreaseSpawnRate()
    {
        if (CanUpgrade())
        {
            manager.Gold -= UpgradeCost;
            UpgradeCost = (int)(UpgradeCost * 1.5f);
            MaxTimer -= 0.5f;
            SpawnTimer -= 0.5f;
            closeUpgradeMenu();
        }
    }

    public void IncreaseLevel()
    {
        if (CanUpgrade())
        {
            manager.Gold -= UpgradeCost;
            UpgradeCost = (int)(UpgradeCost * 1.5f);
            Level += 1;
            closeUpgradeMenu();
        }
    }

    public void IncreaseSpawnChance()
    {
        if (CanUpgrade())
        {
            manager.Gold -= UpgradeCost;
            UpgradeCost = (int)(UpgradeCost * 1.5f);
            manager.ZombieSpawnChance += 0.1f;
            closeUpgradeMenu();
        }
    }
}
