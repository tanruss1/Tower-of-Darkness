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

    public bool canBuild = true;
    bool PoisonGasActive = false;
    float PoisonTimer = 1f;
    int PoisonCount = 0;
    public GameObject[] heroes = new GameObject[3];

    private void Start()
    {
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
        GameObject _minion = Instantiate(minion, Spawnpoint, false);
        //Set _minion level to equal int level
    }
}
