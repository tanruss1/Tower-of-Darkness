using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Transform CameraPos;
    [SerializeField]
    Room_Basic[] Rooms;

    [SerializeField]
    public int Gold = new int();
    [SerializeField]
    public int Gems = new int();

    [SerializeField]
    int FireballCost = 10;
    [SerializeField]
    int PoisonGasCost = 15;
    [SerializeField]
    int DarkAuraCost = 20;

    [SerializeField]
    public float ZombieSpawnChance = 0f;

    bool FireballReady = false;
    bool PoisonGasReady = false;
    bool DarkAuraReady = false;

    [SerializeField]
    GameObject[] Heroes;

    bool[] HeroesAlive = new bool[3];
    float[] HeroSpawnTimer = new float[3] { 10, 10, 10 };
    GameObject[] Minions;

    private void Start()
    {
        Heroes = new GameObject[3];
    }
    void Update()
    {
        //Inputs
        if (Input.GetMouseButtonDown(0))
        {
            GameObject target = GetMouseTarget();
            if (target != null)
            {
                if (target.GetComponent<Room_Basic>())
                {
                    Debug.Log("targeted room");
                    if (FireballReady)
                        CastFireball(target);
                    else if (PoisonGasReady)
                        CastPoisonGas(target);
                    else if (DarkAuraReady)
                        CastDarkAura();
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            PrepareFireball();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            PreparePoisonGas();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            PrepareDarkAura();
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

    public void SpawnMinion (GameObject minion, int level)
    {
        for (int i = 11; i <= 0; i--)
        {
            if (Rooms[i].gameObject.activeInHierarchy)
            {
                Rooms[i].GetComponent<Room_Basic>().SpawnMinion(minion, level);
                break;
            }
        }
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
            if (target.transform.parent.tag == "Room")
                target = target.transform.parent.gameObject;
            else
                return null;

            Debug.Log(target.ToString());

            return target;
        }
        else
        {
            Debug.DrawRay(CameraPos.position, (hit.point - CameraPos.position), Color.red, 100f);
            Debug.Log("Did not hit");
            return null;
        }
    }

    public void PrepareFireball()
    {
        if (Gems >= FireballCost)
        {
            Debug.Log("Fireball ready");
            FireballReady = true;
            Gems -= FireballCost;
        }
        else
            Debug.Log("Not enough gems");
    }

    void CastFireball(GameObject target)
    {
        target.GetComponent<Room_Basic>().Fireball();
        FireballReady = false;
    }

    public void PreparePoisonGas()
    {
        if (Gems >= PoisonGasCost)
        {
            Debug.Log("Poison Gas ready");
            PoisonGasReady = true;
            Gems -= PoisonGasCost;
        }
        else
            Debug.Log("not enough gems");
    }

    void CastPoisonGas(GameObject target)
    {
        target.GetComponent<Room_Basic>().PoisonGas();
        PoisonGasReady = false;
    }

    public void PrepareDarkAura()
    {
        if (Gems >= DarkAuraCost)
        {
            Debug.Log("Dark Aura ready");
            DarkAuraReady = true;
            Gems -= DarkAuraCost;
            CastDarkAura();
        }
        else
            Debug.Log("Not enough gems");
    }

    void CastDarkAura()
    {
        Minions = GameObject.FindGameObjectsWithTag("Minion");
        foreach (GameObject minion in Minions)
        {
            minion.GetComponent<UnitStateMachine>().DarkAura();
        }
        DarkAuraReady = false;
        Debug.Log("Dark Aura Cast");
    }

    void ZombieSpawnRoll(int level)
    {
        if (Random.value <= ZombieSpawnChance)
        {
            //replace GameObject with Zombie
            SpawnMinion(new GameObject(), level);
        }
    }

}
