using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Units;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CharacterCreation))]
public class UnitStateMachine : MonoBehaviour
{
    public enum UnitType { Boss, Minion, Hero};

    [SerializeField]
    UnitType Type = UnitType.Boss;

    //Define the states
    public enum states
    {
        Idle,
        Walking,
        Attack,
        Hit,
        Dead,

        Num_states
    };
    private states curState = states.Walking;
    private states prevState = states.Idle;
    private Dictionary<states, Action> stateUpdate = new Dictionary<states, Action>();
    private Dictionary<states, Action> stateEnter = new Dictionary<states, Action>();
    private Dictionary<states, Action> stateExit = new Dictionary<states, Action>();

    [SerializeField]
    private int speed = 3;

    Rigidbody rb;
    private float timer = 0.5f;
    private float cooldown = 0.5f;
    private GameObject[] targets = { null, null, null, null };
    private GameObject obj;
    private BoxCollider collider;
    public Characters stats;

    bool DarkAuraActive = false;
    float DarkAuraTimer;

    public int Health;
    public int MaxHealth;
    public int Attack;
    public int AttackSpeed;
    public int Range;
    public int Exp;
    public int ExpToNext;
    public int Level;


    // Start is called before the first frame update
    void Start()
    {

        rb = this.GetComponent<Rigidbody>();
        collider = this.GetComponent<BoxCollider>();
        stats = GetComponent<CharacterCreation>().character;

        //Load the main Enter functions into the state machine
        stateEnter.Add(states.Idle, Idle_Enter);
        stateEnter.Add(states.Walking, Walking_Enter);
        stateEnter.Add(states.Attack, Attack_Enter);
        stateEnter.Add(states.Hit, Hit_Enter);
        stateEnter.Add(states.Dead, Dead_Enter);

        //Load the main Update functions into the state machine
        stateUpdate.Add(states.Idle, Idle_Update);
        //stateUpdate.Add(states.Walking, Walking_Update);
        stateUpdate.Add(states.Attack, Attack_Update);
        stateUpdate.Add(states.Hit, Hit_Update);
        stateUpdate.Add(states.Dead, Dead_Update);

        //load the main Exit functions into the state machine
        stateExit.Add(states.Idle, Idle_Exit);
        stateExit.Add(states.Walking, Walking_Exit);
        stateExit.Add(states.Attack, Attack_Exit);
        stateExit.Add(states.Hit, Hit_Exit);
        stateExit.Add(states.Dead, Dead_Exit);

        //Initialize state machine based on which version
        if (Type == UnitType.Boss)
            Boss();
        else if (Type == UnitType.Minion)
            Minion();
        else
            Hero();


        Health = stats.Health;
        MaxHealth = stats.Maxhealth;
        Attack = stats.Attack;
        AttackSpeed = stats.Speed;
        Range = stats.Range;
        Exp = stats.Exp;
        ExpToNext = stats.ExpToNext;
        Level = stats.Level;
        cooldown = 1.5f - (stats.Speed * 0.25f);
        timer = cooldown;
        collider.size = new Vector3(0.5f, 0.5f, stats.Range * 1.25f);
        collider.center = new Vector3(0, 1, 0.5f + (float)stats.Range / 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        stateUpdate[curState].Invoke();

        if (DarkAuraActive)
        {
            DarkAuraTimer -= Time.deltaTime;
            if (DarkAuraTimer <= 0)
                EndDarkAura();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<UnitStateMachine>())
        {
            UnitType otherType = other.GetComponent<UnitStateMachine>().Type;
           

            if (Type == UnitType.Hero && (otherType == UnitType.Minion || otherType == UnitType.Boss))
            {
                for (int i = 0; i < 4; i++)
                {
                    if (targets[i] == null)
                    {
                        targets[i] = other.gameObject;
                    }
                }
                ChangeState(states.Attack);
            }
            else if((Type == UnitType.Boss || Type == UnitType.Minion) && otherType == UnitType.Hero)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (targets[i] == null)
                    {
                        targets[i] = other.gameObject;
                    }
                }
                ChangeState(states.Attack);
            }
            else
                ChangeState(states.Idle);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<UnitStateMachine>())
        {
            UnitType otherType = other.GetComponent<UnitStateMachine>().Type;


            if (Type == UnitType.Hero && (otherType == UnitType.Minion || otherType == UnitType.Boss))
            {
                for (int i = 0; i < 4; i++)
                {
                    if (targets[i] == other.gameObject)
                    {
                        targets[i] = null;
                    }
                }
            }
            else if ((Type == UnitType.Boss || Type == UnitType.Minion) && otherType == UnitType.Hero)
            {
                for (int i = 0; i < 4; i++)
                {
                    if (targets[i] == other.gameObject)
                    {
                        targets[i] = null;
                    }
                }
            }
        }
        if (curState == states.Idle)
        {
            ChangeState(states.Walking);
        }
    }

    //The following three functions will be called at start depending on which version of the statemachine is being initialized
    void Boss()
    {
        stateUpdate.Add(states.Walking, Boss_Walking_Update);
    }

    void Minion()
    {
        stateUpdate.Add(states.Walking, Minion_Walking_Update);
    }

    void Hero()
    {
        stateUpdate.Add(states.Walking, Hero_Walking_Update);
    }

    //The following function controls the state machine
    public void ChangeState(states newState)
    {
        prevState = curState;
        curState = newState;
        stateExit[prevState].Invoke();
        stateEnter[curState].Invoke();
    }

    //The following functions are the base states that will be used unless the selected enum has a special one
    //Enter functions
    void Idle_Enter()
    {
        Debug.Log("sittingstill");
    }

    void Walking_Enter()
    {
        Debug.Log("I'm Walking here");
    }

    void Attack_Enter()
    {
        Debug.Log("attacking!");
    }

    void Hit_Enter()
    {

    }

    void Dead_Enter()
    {
        Debug.Log(this.gameObject.name + " is dead");
        Destroy(this.gameObject);
    }

    //Update functions
    void Idle_Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            for (int i = 0; i < 4; i++)
            {
                if (targets[i] != null)
                {
                    ChangeState(states.Attack);
                    timer = cooldown;
                    break;
                }
            }
            ChangeState(states.Walking);
            timer = cooldown;
        }
    }

    void Attack_Update()
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Debug.Log("attacked");
            foreach (GameObject target in targets)
            {
                target.GetComponent<UnitStateMachine>().TakeDamage(Attack, this.gameObject);
            }
            timer = cooldown;
            ChangeState(states.Idle);
        }
    }


    void Hit_Update()
    {

    }

    void Dead_Update()
    {

    }

    //Exit functions
    void Idle_Exit()
    {
       
    }

    void Walking_Exit()
    {

    }

    void Attack_Exit()
    {

    }

    void Hit_Exit()
    {

    }

    void Dead_Exit()
    {

    }
    //these functions are specific to a single enemurator
    void Boss_Walking_Update()
    {

    }

    void  Minion_Walking_Update()
    {
        rb.velocity = rb.transform.forward * speed;
    }

    void Hero_Walking_Update()
    {
        rb.velocity = rb.transform.forward * speed;
    }

    //These functions apply changes to the character's stats
    public void TakeDamage(int damage, GameObject attacker)
    {
        Health -= damage;
        Debug.Log(this.gameObject + " has " + Health + " health remaining");
        if (Health <= 0)
        {
            ChangeState(states.Dead);
        }
    }

    public void GainExp(int exp)
    {
        Exp += exp;
        if (Exp >= ExpToNext)
            LevelUp();
    }

    public void LevelUp()
    {
        Level += 1;

        if (Type == UnitType.Minion)
        {
            Health += 2;
            MaxHealth += 2;
            Attack += 1;
            Exp += 1;
        }
        else if (Type == UnitType.Hero)
        {
            Health += 1;
            MaxHealth += 1;
            Attack += 1;
            Exp -= ExpToNext;
            ExpToNext += 10;
        }
    }

    public void DarkAura()
    {
        Attack += 2;
        Speed += 2;

        DarkAuraActive = true;
        DarkAuraTimer = 10f;
        Debug.Log("Dark Aura activated on " + this.gameObject.name);
    }

    public void EndDarkAura()
    { 
        Attack -= 2;
        Speed -= 2;

        DarkAuraActive = false;
    }
}
