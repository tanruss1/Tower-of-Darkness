using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField]
    private Transform hero;
    private Transform hero2;
    private Transform hero3;
    private Transform RespawnPoint;

    private void OnDestroy()
    {
        hero.position = RespawnPoint.transform.position;
        hero2.position = RespawnPoint.transform.position;
        hero3.position = RespawnPoint.transform.position;
    }
}
