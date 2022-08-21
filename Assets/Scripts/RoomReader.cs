using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomReader : MonoBehaviour
{
    int heroesLeft = 0;
    int minionsLeft = 0;
    
    
    // Update is called once per frame
    void Update()
    {
        GameObject[] heroes = GameObject.FindGameObjectsWithTag("Hero");
        heroesLeft = heroes.Length;
        if (heroesLeft >= 0)
        {
            string enemyMessage = "There are" + heroesLeft.ToString() + " heroes left";
        }
        if (heroesLeft == 0)
        {
            Debug.Log("enemiesGone");
        }

        GameObject[] minions = GameObject.FindGameObjectsWithTag("Minion");
        heroesLeft = heroes.Length;
        if (minionsLeft >= 0)
        {
            string minionMessage = "There are" + minionsLeft.ToString() + " minions left";
        }
        if (minionsLeft == 0)
        {
            Debug.Log("MinionsGone");
        }

    }




}
