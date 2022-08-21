using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    Transform CameraPos;
    [SerializeField]
<<<<<<< HEAD
    Room_Basic[] Rooms;
    [SerializeField]
    Transform HeroSpawn;
=======
    GameObject[] Rooms;
>>>>>>> parent of 4c03e1d (Merge branch 'test')

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

<<<<<<< HEAD
    [SerializeField]
    UnitStateMachine[] Heroes;

    bool[] HeroesAlive = new bool[3];
    float[] HeroSpawnTimer = new float[3] { 10, 10, 10 };
    GameObject[] Minions;

    private void Start()
    {
        
    }
=======
    GameObject[] Heroes = new GameObject[3];
    bool[] HeroesAlive = new bool[3];
    float[] HeroSpawnTimer = new float[3] { 10, 10, 10 };
    GameObject[] Minions;
    
    
>>>>>>> parent of 4c03e1d (Merge branch 'test')
    void Update()
    {
        //Inputs
        if (Input.GetMouseButtonDown(0))
        {
            GameObject target = GetMouseTarget();
            if (target.tag == "Room")
            {
<<<<<<< HEAD
                Debug.Log("target acquired");
                if (target.GetComponent<Room_Basic>())
                {
                    Room_Basic room = target.GetComponent<Room_Basic>();
                    Debug.Log("targeted room");
                    if (FireballReady)
                        CastFireball(target);
                    else if (PoisonGasReady)
                        CastPoisonGas(target);
                    else if (DarkAuraReady)
                        CastDarkAura();
                    else if (target.GetComponent<Room_Basic>().canBuild)
                    {
                        this.GetComponent<UIManager>().UpgradeRoomMenu(room.MainText, room.Upgrade1_Text, "Cost: " + room.UpgradeCost, room.Upgrade1, room. Upgrade2_Text, room.Upgrade2);
                    }
                }
=======
                Debug.Log("targeted room");
                if (FireballReady)
                    CastFireball(target);
                else if (PoisonGasReady)
                    CastPoisonGas(target);
                else if (DarkAuraReady)
                    CastDarkAura(target);
>>>>>>> parent of 4c03e1d (Merge branch 'test')
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
        for (int i = 0; i < Heroes.Length; i++)
        {
            if (!Heroes[i].isAlive)
            {
                HeroSpawnTimer[i] -= Time.deltaTime;
                if (HeroSpawnTimer[i] <= 0)
                {
                    SpawnHero(Heroes[i]);
                    HeroSpawnTimer[i] = 10;
                }
            }
        }
    }

    void SpawnHero(UnitStateMachine hero)
    {
        for (int i = 0; i < Heroes.Length; i++)
        {
            if (!Heroes[i].isAlive)
            {
                Heroes[i].gameObject.transform.position = HeroSpawn.position;
                Heroes[i].Health = Heroes[i].MaxHealth;
                Heroes[i].gameObject.SetActive(true);
            }
        }
    }

    public void SpawnMinion (GameObject minion, int level)
    {
        for (int i = 11; i <= 0; i--)
        {
            if (Rooms[i].activeInHierarchy)
            {
                Rooms[i].GetComponent<Room_Basic>().SpawnMinion(minion, level);
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
<<<<<<< HEAD
            if (target.GetComponent<Room_Basic>())
            {
                //target = target.transform.parent.gameObject;
            }
            else
                return null;
=======
            if (target.transform.parent.tag == "Room")
                target = target.transform.parent.gameObject;
>>>>>>> parent of 4c03e1d (Merge branch 'test')

            Debug.Log("hit " + target.ToString());

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
        }
        Debug.Log("Not enough gems");
    }

    void CastDarkAura(GameObject target)
    {
        Minions = GameObject.FindGameObjectsWithTag("Minion");
        foreach (GameObject minion in Minions)
        {
            //Trigger buff, +2 attack and speed
        }
        DarkAuraReady = false;
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
