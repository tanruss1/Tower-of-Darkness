using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room_Resource : Room_Basic
{
    //True for gold, False for gems
    [SerializeField]
    bool GoldOrGems;
    [SerializeField]
    int level = 1;
    [SerializeField]
    float Timer = 10f;

    // Update is called once per frame
    void Update()
    {
        Timer -= Time.deltaTime;
        if (Timer <= 0)
        {
            Timer = 10f;
            GiveResource();
        }
    }

    void GiveResource()
    {
        if (GoldOrGems)
            manager.Gold += level;
        else
            manager.Gems += level;
    }
}
