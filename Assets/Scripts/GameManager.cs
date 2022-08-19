using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Transform CameraPos;
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
        //Inputs
        if (Input.GetMouseButtonDown(0))
        {
            GetMouseTarget();
        }

        //Check to see if heroes can respawn
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

    GameObject GetMouseTarget()
    {
        GameObject target = new GameObject();
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        if (Physics.Raycast(ray, out hit , 100f))
        {
            Debug.DrawRay(CameraPos.position, (hit.point - CameraPos.position), Color.yellow, 100f);
            Debug.Log("Did hit");

            target = hit.collider.gameObject;
            return target;
        }
        else
        {
            Debug.DrawRay(CameraPos.position, (hit.point - CameraPos.position), Color.red, 100f);
            Debug.Log("Did not hit");
            return null;
        }
    }
}
