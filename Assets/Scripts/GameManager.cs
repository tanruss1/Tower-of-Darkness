using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    int Gold = new int();
    [SerializeField]
    int Gems = new int();
    GameObject[] Heroes = new GameObject[3];
    bool[] HeroesAlive = new bool[3];
    float[] HeroSpawnTimer = new float[3] { 10, 10, 10 };
    GameObject[] Minions;
    GameObject[] Rooms = new GameObject[12];
    
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (!HeroesAlive[i])
            {
                HeroSpawnTimer[i] -= Time.deltaTime;
                if (HeroSpawnTimer[i] <= 0)
                {
                    SpawnHero(Heroes[i]);
                    HeroesAlive[i] = true;
                    HeroSpawnTimer[i] = 10;
                }
            }
        }
    }

    void SpawnHero(GameObject hero)
    {

    }
}
