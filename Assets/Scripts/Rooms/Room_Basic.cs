using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Room_Basic : MonoBehaviour
{
    [SerializeField]
    Transform Spawnpoint;
    [SerializeField]
    ParticleSystem FireballParticles;
    [SerializeField]
    ParticleSystem PoisonGasParticles;
    [SerializeField]
    public GameManager manager;

    public string MainText;
    public UnityEngine.Events.UnityAction Upgrade1;
    public string Upgrade1_Text;
    public UnityEngine.Events.UnityAction Upgrade2;
    public string Upgrade2_Text;

    public bool canBuild = true;
    bool PoisonGasActive = false;
    float PoisonTimer = 1f;
    int PoisonCount = 0;
    public GameObject[] heroes;
    public int UpgradeCost = 10;

    private void Start()
    {
        heroes = new GameObject[3] { null, null, null };

        GameObject[] objects = FindObjectsOfType<GameObject>();
        foreach (GameObject _object in objects)
        {
            if (_object.GetComponent<GameManager>())
                manager = _object.GetComponent<GameManager>();
        }

    }

    private void Update()
    {
        if (PoisonGasActive)
        {
            if (PoisonTimer > 0)
                PoisonTimer -= Time.deltaTime;
            else
            {
                foreach (GameObject hero in heroes)
                {
                    //Reduce health by 1
                }
                PoisonTimer = 1f;
                PoisonCount += 1;
                if (PoisonCount >= 5)
                {
                    PoisonGasActive = false;
                    PoisonCount = 0;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Hero")
        {
            for (int i = 0; i < 3; i++)
            {
                if (heroes[i] == null)
                    heroes[i] = other.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Hero")
        {
            for (int i = 0; i < 3; i++)
            {
                if (heroes[i] == other.gameObject)
                    heroes[i] = null;
            }
        }
    }

    public void Fireball()
    {
        foreach (GameObject hero in heroes)
        {
            FireballParticles.Play();
            //reduce health by 10
        }
    }

    public void PoisonGas()
    {
        PoisonGasActive = true;
        PoisonGasParticles.Play();
    }

    public void SpawnMinion(GameObject minion, int level)
    {
        Debug.Log("Attempting minion spawn in " + this.gameObject.name);
        GameObject _minion = Instantiate(minion, Spawnpoint, false);
        _minion.GetComponent<UnitStateMachine>().stats.Level = level;
        //Set _minion level to equal int level
        if (_minion.transform.position != null)
            Debug.Log("Minion spawned successfully");
    }

    public bool CanUpgrade()
    {
        if (manager.Gold >= UpgradeCost)
            return true;
        else 
            return false;
    }
}
