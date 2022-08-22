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
    Transform HeroSpawn;

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

    public int FireballDamage = 5;
    public float PoisonGasDamage = 1f;
    public float DarkAuraBuff = 2f;

    [SerializeField]
    public float ZombieSpawnChance = 0f;

    bool FireballReady = false;
    bool PoisonGasReady = false;
    bool DarkAuraReady = false;

    [SerializeField]
    UnitStateMachine[] Heroes;

    bool[] HeroesAlive = new bool[3];
    float[] HeroSpawnTimer = new float[3] { 10, 10, 10 };
    GameObject[] Minions;

    [SerializeField]
    AudioClip fireballSound;
    [SerializeField]
    AudioClip poisonGasSound;
    [SerializeField]
    AudioClip darkAuraSound;

    private void Start()
    {
        
    }
    void Update()
    {
        //Inputs
        if (Input.GetMouseButtonDown(0))
        {
            GameObject target = GetMouseTarget();
            if (target != null)
            {
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
                    else if (!target.GetComponent<Room_Basic>().canBuild)
                    {
                        this.GetComponent<UIManager>().UpgradeRoomMenu(room.MainText, room.Upgrade1_Text, "Cost: " + room.UpgradeCost, room.Upgrade1, room. Upgrade2_Text, room.Upgrade2);
                    }
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
        Debug.Log("Spawning " + hero.gameObject.name);
        hero.gameObject.transform.position = HeroSpawn.position;
        hero.Health = hero.MaxHealth;
        hero.isAlive = true;
        hero.gameObject.SetActive(true);
        hero.ChangeState(UnitStateMachine.states.Walking);
    }

    public void SpawnMinion (GameObject minion, int level)
    {
        Debug.Log("Minion spawn triggered in manager");
        for (int i = 11; i >= 0; i--)
        {
            if (Rooms[i].gameObject.activeInHierarchy)
            {
                Debug.Log("Spawning level " + level.ToString() + " " + minion.name + " in " + Rooms[i].gameObject.name);
                Rooms[i].SpawnMinion(minion, level);
                return;
            }
            Debug.Log("Room " + Rooms[i].gameObject.name + " is inactive or not assigned");
        }
        Debug.LogError("Failed to spawn minion");
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
            if (target.GetComponent<Room_Basic>())
            {
                //target = target.transform.parent.gameObject;
            }
            else
                return null;

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
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(fireballSound);
        target.GetComponent<Room_Basic>().Fireball(FireballDamage);
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
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(poisonGasSound);
        target.GetComponent<Room_Basic>().PoisonGas((int)PoisonGasDamage);
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
        this.gameObject.GetComponent<AudioSource>().PlayOneShot(darkAuraSound);
        Minions = GameObject.FindGameObjectsWithTag("Minion");
        foreach (GameObject minion in Minions)
        {
            minion.GetComponent<UnitStateMachine>().DarkAura((int)DarkAuraBuff);
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
