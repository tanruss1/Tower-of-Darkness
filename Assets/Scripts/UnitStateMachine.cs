using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(BoxCollider))]
public class UnitStateMachine : MonoBehaviour
{
    //Decide on the behavior based on the type of unit
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
    private states curState = states.Idle;
    private states prevState = states.Idle;
    private Dictionary<states, Action> stateUpdate = new Dictionary<states, Action>();
    private Dictionary<states, Action> stateEnter = new Dictionary<states, Action>();
    private Dictionary<states, Action> stateExit = new Dictionary<states, Action>();

    // Start is called before the first frame update
    void Start()
    {
        //Load the main Enter functions into the state machine
        stateEnter.Add(states.Idle, Idle_Enter);
        stateEnter.Add(states.Walking, Walking_Enter);
        stateEnter.Add(states.Attack, Attack_Enter);
        stateEnter.Add(states.Hit, Hit_Enter);
        stateEnter.Add(states.Dead, Dead_Enter);

        //Load the main Update functions into the state machine
        stateUpdate.Add(states.Idle, Idle_Update);
        stateUpdate.Add(states.Walking, Walking_Update);
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
    }

    // Update is called once per frame
    void Update()
    {
        stateUpdate[curState].Invoke();
    }

    //The following three functions will be called at start depending on which version of the statemachine is being initialized
    void Boss()
    {

    }

    void Minion()
    {

    }

    void Hero()
    {

    }

    //The following function controls the state machine
    void ChangeState(states newState)
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

    }

    void Walking_Enter()
    {

    }

    void Attack_Enter()
    {

    }

    void Hit_Enter()
    {

    }

    void Dead_Enter()
    {

    }

    //Update functions
    void Idle_Update()
    {

    }

    void Walking_Update()
    {

    }

    void Attack_Update()
    {

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
}
