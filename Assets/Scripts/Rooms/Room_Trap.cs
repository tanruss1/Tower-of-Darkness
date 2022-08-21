using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Room_Trap : Room_Basic
{
    public enum TrapType { Arrow, Spike, Fire}

    float TimerMax = 10f;
    int Damage;
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

            Upgrade1 = IncreaseHitChances;
            Upgrade1_Text = "Upgrade number of shots";
        }
        else if (type == TrapType.Spike)
        {
            usesTimer = false;
            usesTrigger = true;
            HitChances = 1;
            HitProb = 0.8f;
            Damage = 5;

            Upgrade1 = IncreaseHitProb;
            Upgrade1_Text = "Increase chance to hit";
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

            Upgrade1 = DecreaseTimer;
            Upgrade1_Text = "Decrease time between flames";
        }

        Upgrade2 = IncreaseDamage;
        Upgrade2_Text = "Increase damage";
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
        foreach (GameObject hero in heroes)
        {
            for (int i = 0; i < HitChances; i++)
            {
                if (rnd.NextDouble() <= (double)HitProb)
                {
                    hero.GetComponent<UnitStateMachine>().TakeDamage(Damage, this.gameObject);
                }
            }
        }
    }

    void IncreaseHitProb()
    {
        if (CanUpgrade())
        {
            manager.Gold -= UpgradeCost;
            UpgradeCost =(int)(UpgradeCost * 1.5f);
            HitProb += 0.01f;
        }
    }

    void IncreaseHitChances()
    {
        if (CanUpgrade())
        {
            manager.Gold -= UpgradeCost;
            UpgradeCost = (int)(UpgradeCost * 1.5f);
            HitChances += 1;
        }
    }

    void IncreaseDamage()
    {
        if (CanUpgrade())
        {
            manager.Gold -= UpgradeCost;
            UpgradeCost = (int)(UpgradeCost * 1.5f);
            Damage += 1;
        }
    }

    void DecreaseTimer()
    {
        if (CanUpgrade())
        {
            manager.Gold -= UpgradeCost;
            UpgradeCost = (int)(UpgradeCost * 1.5f);
            TimerMax -= 0.01f;
        }
    }
}
