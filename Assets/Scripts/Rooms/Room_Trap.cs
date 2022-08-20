using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Room_Trap : Room_Basic
{
    public enum TrapType { Arrow, Spike, Fire}

    float TimerMax = 10f;
    private int Damage;
    [SerializeField]
    TrapType type = TrapType.Arrow;

    bool usesTimer;
    bool usesTrigger;
    float timer;
    System.Random rnd;
    int HitChances;
    float HitProb;

    // Start is called before the first frame update
    void Start()
    {
        canBuild = false;
        timer = TimerMax;
        if (type == TrapType.Arrow)
        {
            usesTimer = false;
            usesTrigger = true;
            HitChances = 3;
            HitProb = 0.75f;
            Damage = 1;
        }
        else if (type == TrapType.Spike)
        {
            usesTimer = false;
            usesTrigger = true;
            HitChances = 1;
            HitProb = 0.8f;
            Damage = 5;
        }
        else if (type == TrapType.Fire)
        {
            usesTimer = true;
            usesTrigger = false;
            TimerMax = 1f;
            timer = 1f;
            HitChances = 1;
            HitProb = 1;
            Damage = 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (usesTimer)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                ApplyDamage();
                timer = TimerMax;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (usesTrigger)
            ApplyDamage();
    }

    void ApplyDamage()
    {
        foreach (GameObject Heroes in heroes)
        {
            for (int i = 0; i < HitChances; i++)
            {
                if (rnd.NextDouble() <= (double)HitProb)
                {
                    //Apply damage equal to Damage
                }
            }
        }
    }
}
