using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomReader : MonoBehaviour
{
    int enemiesLeft = 0;
    int minionsLeft = 0;
    
    
    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        enemiesLeft = enemies.Length;
        if (enemiesLeft >= 0)
        {
            string enemyMessage = "There are" + enemiesLeft.ToString();
        }
        if (enemiesLeft == 0)
        {
            Debug.Log("enemiesGone");
        }

        GameObject[] minions = GameObject.FindGameObjectsWithTag("minion");
        enemiesLeft = enemies.Length;
        if (minionsLeft >= 0)
        {
            string minionMessage = "There are" + minionsLeft.ToString();
        }
        if (minionsLeft == 0)
        {
            Debug.Log("MinionsGone");
        }

    }




}
