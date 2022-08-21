using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class TpTrigger : MonoBehaviour
{
    [SerializeField]
    public UnitStateMachine.UnitType type;
    [SerializeField]
    public bool tpHero = false;
    [SerializeField]
    public bool tpMinion = false;
    [SerializeField]
    public Transform tpPoint;

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Trigger entered by " + other.gameObject.name);
        if (other.gameObject.GetComponent<UnitStateMachine>())
        {
            //Debug.Log("State machine detected on " + other.gameObject.name);
            if (other.gameObject.GetComponent<UnitStateMachine>().Type == type)
            {
                //Debug.Log(other.gameObject.name + " matches tp type");
                if (type == UnitStateMachine.UnitType.Hero && tpHero)
                {
                    //Debug.Log("Teleporting hero");
                    other.gameObject.transform.position = tpPoint.position;
                }
                else if (type == UnitStateMachine.UnitType.Minion && tpMinion)
                {
                    //Debug.Log("Teleporting minion");
                    other.gameObject.transform.position = tpPoint.position;
                }
            }
        }
    }
}
